using Glasno.Common.Core;
using Glasno.Common.Database.RDBMS;
using Glasno.Common.Exceptions;
using Glasno.Common.Host;
using Glasno.Common.Kafka.Options;

using KafkaFlow;

namespace MAIKotiki.MAFConstructor.Presentation;

public class Startup(IConfiguration configuration)
{
	public void ConfigureServices(IServiceCollection services)
	{
		// core
		GlasnoCoreInjection.Configure(services, configuration);
		DatabaseInjection.Configure(services, configuration);

		ConfigureKafka(services);

		// modules

	}

	public IServiceCollection ConfigureKafka(IServiceCollection services)
	{
		KafkaConfiguration kafkaConfig = configuration.GetSection(nameof( KafkaConfiguration ))
			                                 .Get<KafkaConfiguration>()
		                                 ?? throw new ConfigurationException();
	
		var kafkaBuilder = services.AddKafka(kafkaConfigurationBuilder =>
		{
			kafkaConfigurationBuilder
				.UseConsoleLog()
				.AddCluster(cluster =>
				{
					cluster.WithBrokers(kafkaConfig.Brokers)
						.EnableAdminMessages("kafkaflow.admin");

					// add injections
				});
			
			KafkaFlow.Configuration.ExtensionMethods.AddOpenTelemetryInstrumentation(kafkaConfigurationBuilder,
				options =>
				{
					options.EnrichProducer =
                        				(activity, messageContext) =>
                        				{
                        					activity
                        						.SetTag("messaging.destination.producername", "KafkaFlowOtel");
                        				};
                        
                        			options.EnrichConsumer =
                        				(activity, messageContext) =>
                        				{
                        					activity
                        						.SetTag("messaging.destination.groupid", messageContext.ConsumerContext.GroupId);
                        				};						
				});
		});
	
		return services;
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		GlasnoHostConfigurator.Configure(app, env);
	}
}
