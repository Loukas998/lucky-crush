using AutoMapper;
using LuckyCrush.Application.GlobalTypes.Dtos;
using LuckyCrush.Domain.Entities.Globals;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.GlobalTypes.Commands.Create;

public class CreateGlobalTypeCommandHandler(IGlobalTypeRepository globalTypeRepository, IMapper mapper,
    ILogger<CreateGlobalTypeCommandHandler> logger)
    : IRequestHandler<CreateGlobalTypeCommand, Result<GlobalTypeDto>>
{
    public async Task<Result<GlobalTypeDto>> Handle(CreateGlobalTypeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new type: @{GlobalType}", request);
        var globalType = mapper.Map<GlobalType>(request);

        var created = await globalTypeRepository.AddAsync(globalType);
        var result = mapper.Map<GlobalTypeDto>(created);
        return Result<GlobalTypeDto>.Success(result);
    }
}
