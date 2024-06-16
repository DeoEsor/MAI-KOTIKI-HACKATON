namespace MAIKotiki.MAFConstructor.Infrastructure.Repository.Contracts;

internal record SystemChannelConfigurationDb
{
    public required long ChannelId { get; set; }
    public required bool Enabled { get; set; }
    public required string InstrumentToken { get; set; }
    public required string OrderSideToken { get; set; }
    public required string EntryPriceToken { get; set; }
    public required string StopPriceToken { get; set; }
    public required string TargetPriceToken { get; set; }
    public required string RiskPriceToken { get; set; }
    public required string RRRToken { get; set; }
}