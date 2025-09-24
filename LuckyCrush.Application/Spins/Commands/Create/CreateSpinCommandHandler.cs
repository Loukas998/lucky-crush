using AutoMapper;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Spins.Commands.Create;

public class CreateSpinCommandHandler(ILogger<CreateSpinCommandHandler> logger, IMapper mapper,
    ISpinRepository spinRepository) : IRequestHandler<CreateSpinCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateSpinCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new spin: {@Spin}", request);
        var spin = mapper.Map<Spin>(request);
        var created = await spinRepository.AddAsync(spin);
        return Result<int>.Success(created.Id);
    }
}
