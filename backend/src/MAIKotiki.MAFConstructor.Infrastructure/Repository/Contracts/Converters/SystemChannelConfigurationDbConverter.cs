using Riok.Mapperly.Abstractions;

namespace MAIKotiki.MAFConstructor.Infrastructure.Repository.Contracts.Converters;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
internal static partial class SystemChannelConfigurationDbConverter
{
    public static partial SystemChannelConfigurationDb ToDb(SystemChannelConfiguration configuration);
    
    public static partial SystemChannelConfiguration ToDomain(SystemChannelConfigurationDb configuration);
}