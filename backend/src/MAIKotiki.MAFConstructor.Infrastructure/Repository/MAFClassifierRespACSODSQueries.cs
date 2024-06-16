using Dapper;

using MAIKotiki.MAFConstructor.Infrastructure.Repository.Contracts;

namespace MAIKotiki.MAFConstructor.Infrastructure.Repository;

internal class MAFClassifierRespACSODSQueries
{
    public static CommandDefinition GetById(long channelId, CancellationToken cancellationToken)
    {
        const string query =
            $"""
             select *
             from MAF_classifier_resp_ACS_ODS
             where "No. according to the nomenclature of the MAF MONITOR" = @Id
             """;
        return new CommandDefinition
        (
            query,
            new
            {
                Id = channelId
            },
            cancellationToken: cancellationToken
        );
    }

    public static CommandDefinition Add(SystemChannelConfigurationDb entity, CancellationToken cancellationToken)
    {
        const string query =
            $"""
             INSERT INTO system_configuration
             (
             	channel_id,
                enabled,
                instrument_token,
                orderSide_token,
                entry_price_token,
                stop_price_token,
                target_price_token,
                risk_price_token,
                rrr_token
             )
             VALUES
             (
             	@ChannelId,
                @Enabled,
                @InstrumentToken,
                @OrderSideToken,
                @EntryPriceToken,
                @StopPriceToken,
                @TargetPriceToken,
                @RiskPriceToken,
                @RRRToken
             );
             """;
        return new CommandDefinition
        (
            query,
            new
            {
                entity.ChannelId
                ,entity.Enabled
                ,entity.InstrumentToken
                ,entity.OrderSideToken
                ,entity.EntryPriceToken
                ,entity.StopPriceToken
                ,entity.TargetPriceToken
                ,entity.RiskPriceToken
                ,entity.RRRToken
            },
            cancellationToken: cancellationToken
        );
    }

    public static CommandDefinition Update(SystemChannelConfigurationDb entity, CancellationToken cancellationToken)
    {
        const string query =
            $"""
             UPDATE system_configuration
             SET
                enabled = @Enabled,
                instrument_token = @InstrumentToken,
                orderSide_token = @OrderSideToken,
                entry_price_token = @EntryPriceToken,
                stop_price_token = @StopPriceToken,
                target_price_token = @TargetPriceToken,
                risk_price_token = @RiskPriceToken,
                rrr_token = @RRRToken
             WHERE
                 channel_id = @ChannelId;
             """;
        return new CommandDefinition
        (
            query,
            new
            {
                entity.ChannelId
                ,entity.Enabled
                ,entity.InstrumentToken
                ,entity.OrderSideToken
                ,entity.EntryPriceToken
                ,entity.StopPriceToken
                ,entity.TargetPriceToken
                ,entity.RiskPriceToken
                ,entity.RRRToken
            },
            cancellationToken: cancellationToken
        );
    }

    public static CommandDefinition Search(SystemChannelConfigurationSearchQuery searchQuery, CancellationToken cancellationToken)
    {
        const string query =
            $"""
             select
             	*
             from
             	system_configuration
             where
             	(array_length(@UserIds, 1) is null or user_id = @UserIds) and
             	(@ChannelId is null or @ChannelId = ((channel_configurations->>'channel_id')::boolean)) and
             	(@ReviewedToken is null or @ReviewedToken = ((channel_configurations->>'reviewed_token')::boolean)) and
             	(@Enabled is null or @Enabled = ((channel_configurations->>'enabled')::boolean))
             limit @Limit
             offset @Skip;
             """;
        return new CommandDefinition
        (
            query,
            new
            {
                searchQuery.UserIds,
                searchQuery.ChannelId,
                searchQuery.Enabled,
                searchQuery.ReviewedToken,
                searchQuery.Skip,
                searchQuery.Limit,
            },
            cancellationToken: cancellationToken
        );
    }
}