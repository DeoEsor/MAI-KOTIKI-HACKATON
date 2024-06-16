namespace MAIKotiki.MAFConstructor.Infrastructure.Repository.Contracts;

public class SystemChannelConfigurationSearchQuery
{
    public long[] UserIds { get; set; } = [];
    
    public long? ChannelId { get; set; }
    
    public bool? Enabled { get; set; }
    
    public string? ReviewedToken { get; set; }

    public int Limit { get; set; } = 25;
    
    public int Skip { get; set; } = 0;
}