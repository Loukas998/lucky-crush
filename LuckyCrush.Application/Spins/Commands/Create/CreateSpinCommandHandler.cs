using AutoMapper;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Spins.Commands.Create;

public class CreateSpinCommandHandler(ILogger<CreateSpinCommandHandler> logger, IMapper mapper,
    ISpinRepository spinRepository) : IRequestHandler<CreateSpinCommand, int>
{
    public async Task<int> Handle(CreateSpinCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new spin: {@Spin}", request);
        var spin = mapper.Map<Spin>(request);
        var created = await spinRepository.AddAsync(spin);
        return created.Id;
    }
}
