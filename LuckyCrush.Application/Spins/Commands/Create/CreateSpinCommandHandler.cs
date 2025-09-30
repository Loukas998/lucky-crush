using AutoMapper;
using LuckyCrush.Application.Spins.Dtos;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Spins.Commands.Create;

public class CreateSpinCommandHandler(ILogger<CreateSpinCommandHandler> logger, IMapper mapper,
    ISpinRepository spinRepository) : IRequestHandler<CreateSpinCommand, Result<SpinDto>>
{
    public async Task<Result<SpinDto>> Handle(CreateSpinCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new spin: {@Spin}", request);
        var spin = mapper.Map<Spin>(request);
        var created = await spinRepository.AddAsync(spin);
        var result = mapper.Map<SpinDto>(created);
        return Result<SpinDto>.Success(result);
    }
}
