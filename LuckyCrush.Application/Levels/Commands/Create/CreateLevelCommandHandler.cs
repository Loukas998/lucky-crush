using AutoMapper;
using LuckyCrush.Domain.Entities.Levels;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Levels.Commands.Create;

public class CreateLevelCommandHandler(ILogger<CreateLevelCommandHandler> logger, IMapper mapper,
    ILevelRepository levelRepository) : IRequestHandler<CreateLevelCommand, int>
{
    public async Task<int> Handle(CreateLevelCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new level with Number {Number}, IsSpecial {IsSpecial}, RequiredStars {Stars}",
            request.Number, request.IsSpecial, request.RequiredStars);

        var level = mapper.Map<Level>(request);
        var created = await levelRepository.AddAsync(level);

        return created.Id;
    }
}
