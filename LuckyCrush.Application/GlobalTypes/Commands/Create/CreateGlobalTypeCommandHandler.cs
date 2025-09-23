using AutoMapper;
using LuckyCrush.Domain.Entities.Globals;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.GlobalTypes.Commands.Create;

public class CreateGlobalTypeCommandHandler(IGlobalTypeRepository globalTypeRepository, IMapper mapper,
    ILogger<CreateGlobalTypeCommandHandler> logger)
    : IRequestHandler<CreateGlobalTypeCommand, int>
{
    public async Task<int> Handle(CreateGlobalTypeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new type: @{GlobalType}", request);
        var globalType = mapper.Map<GlobalType>(request);

        var created = await globalTypeRepository.AddAsync(globalType);
        return created.Id;
    }
}
