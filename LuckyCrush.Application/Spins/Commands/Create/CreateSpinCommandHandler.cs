using AutoMapper;
using LuckyCrush.Application.Spins.Dtos;
using LuckyCrush.Application.Users;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;

namespace LuckyCrush.Application.Spins.Commands.Create;

public class CreateSpinCommandHandler(ILogger<CreateSpinCommandHandler> logger, IMapper mapper,
    ISpinRepository spinRepository, IWheelRepository wheelRepository, IUserContext userContext,
    IAccountRepository accountRepository)
    : IRequestHandler<CreateSpinCommand, Result<SpinDto>>
{
    public async Task<Result<SpinDto>> Handle(CreateSpinCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new spin: {@Spin}", request);
        var currentUserId = userContext.GetCurrentUser()!.Id;

        var existingUser = await accountRepository.GetUserWithPrizesAsync(currentUserId);
        if (existingUser == null)
            return Result<SpinDto>.Failure("User not found.");

        var existing = await spinRepository.GetByCorrelationIdAsync(request.CorrelationId);
        if (existing != null)
        {
            logger.LogInformation("Spin duplication");
            var existingDto = mapper.Map<SpinDto>(existing);
            return Result<SpinDto>.Success(existingDto);
        }

        var wheel = await wheelRepository.GetWheelWithPrizesAsync(request.WheelId);
        if (wheel == null)
            return Result<SpinDto>.Failure("Wheel not found.");

        var todaySpins = await spinRepository.CountTodayAsync(currentUserId, wheel.Type);
        if (wheel.Type.Equals("Free", StringComparison.OrdinalIgnoreCase) && todaySpins >= 1)
            return Result<SpinDto>.Failure("Daily free spin already used.");

        var prize = SelectPrize(wheel.Prizes);
        var spin = new Spin
        {
            UserId = currentUserId,
            WheelId = request.WheelId,
            SpinAt = DateTime.UtcNow,
            PrizeId = prize.Id,
            Type = wheel.Type,
            CorrelationId = request.CorrelationId
        };

        existingUser.Prizes.Add(prize);
        var created = await spinRepository.AddAsync(spin);
        var result = mapper.Map<SpinDto>(created);

        logger.LogInformation("Spin created successfully for user {UserId} on wheel {WheelId} -> Prize {PrizeId}",
            currentUserId, request.WheelId, prize.Id);

        return Result<SpinDto>.Success(result);
    }

    private Prize SelectPrize(List<Prize> prizes)
    {
        int totalWeight = prizes.Sum(p => p.Weight);
        int roll = RandomNumberGenerator.GetInt32(totalWeight);

        int cumulative = 0;
        foreach (var prize in prizes)
        {
            cumulative += prize.Weight;
            if (roll < cumulative)
                return prize;
        }

        return prizes.Last();
    }
}
