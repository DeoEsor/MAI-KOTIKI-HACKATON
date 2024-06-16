using System.Data;

using Dapper;

using Glasno.Common.Database.RDBMS.Abstractions;

using MAIKotiki.MAFConstructor.Infrastructure.Repository.Contracts;
using MAIKotiki.MAFConstructor.Infrastructure.Repository.Contracts.Converters;

namespace MAIKotiki.MAFConstructor.Infrastructure.Repository;

public class SystemChannelConfigurationRepository(IDbConnectionFactory factory)
{
    private const string DatabaseName = "configuration_db";

    private readonly IDbConnection _connection = factory.CreateConnection(DatabaseName);

    public async Task<SystemChannelConfiguration> Get(long id, CancellationToken cancellationToken)
    {
        var query = SystemChannelConfigurationQueries.GetById(id, cancellationToken);
        var systemChannelConfigurationDbs = await _connection.QueryAsync<SystemChannelConfigurationDb>(query);

        return systemChannelConfigurationDbs.Select(SystemChannelConfigurationDbConverter.ToDomain).Single();
    }
    
    public async Task<SystemChannelConfiguration[]> Search(SystemChannelConfigurationSearchQuery searchQuery, CancellationToken cancellationToken)
    {
        var query = SystemChannelConfigurationQueries.Search(searchQuery, cancellationToken);
        var systemChannelConfigurationDbs = await _connection.QueryAsync<SystemChannelConfigurationDb>(query);

        return systemChannelConfigurationDbs.Select(SystemChannelConfigurationDbConverter.ToDomain).ToArray();
    }

    public Task Add(SystemChannelConfiguration entity, CancellationToken cancellationToken)
    {
        var dbEntity = SystemChannelConfigurationDbConverter.ToDb(entity);
        CommandDefinition query = SystemChannelConfigurationQueries.Add(dbEntity, cancellationToken);
        return _connection.ExecuteAsync(query);
    }

    public Task Update(SystemChannelConfiguration entity, CancellationToken cancellationToken)
    {
        var dbEntity = SystemChannelConfigurationDbConverter.ToDb(entity);
        CommandDefinition query = SystemChannelConfigurationQueries.Update(dbEntity, cancellationToken);
        return _connection.ExecuteAsync(query);
    }
}