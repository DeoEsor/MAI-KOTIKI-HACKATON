using MAIKotiki.MAFConstructor.Application.Commands.CreateConfiguration.Contracts;
using MAIKotiki.MAFConstructor.Infrastructure.Repository;

using MediatR;

namespace MAIKotiki.MAFConstructor.Application.Commands.CreateConfiguration;

internal class CreateSystemChannelConfigurationCommandHandler(SystemChannelConfigurationRepository systemChannelConfigurationRepository)
    : IRequestHandler<CreateSystemChannelConfigurationCommand, CreateSystemChannelConfigurationCommandResponse>
{
    public async Task<CreateSystemChannelConfigurationCommandResponse> Handle(CreateSystemChannelConfigurationCommand request, CancellationToken cancellationToken)
    {

        var a = await systemChannelConfigurationRepository.Get(id, cancellationToken);

        return new CreateSystemChannelConfigurationCommandResponse(entity);
    }
}