using MAIKotiki.MAFConstructor.Application.Commands.CreateConfiguration.Contracts;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace MAIKotiki.MAFConstructor.Presentation.Controllers;

[ApiController]
public class MAFClassificatorController(IMediator mediator)
{
    [HttpPost(nameof(Get))]
    public Task<CreateSystemChannelConfigurationCommandResponse> Get(CreateSystemChannelConfigurationCommand command,
        CancellationToken cancellationToken)
    {
        return mediator.Send(command, cancellationToken);
    }
}