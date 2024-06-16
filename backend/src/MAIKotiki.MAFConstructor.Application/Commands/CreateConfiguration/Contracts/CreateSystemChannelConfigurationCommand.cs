using MediatR;

namespace MAIKotiki.MAFConstructor.Application.Commands.CreateConfiguration.Contracts;

public sealed record CreateSystemChannelConfigurationCommand
(
    long ChannelId,
    bool Enabled,
    string InstrumentToken,
    string OrderSideToken,
    string EntryPriceToken,
    string StopPriceToken,
    string TargetPriceToken,
    string RiskPriceToken,
    string RRRToken   
) : IRequest<CreateSystemChannelConfigurationCommandResponse>;