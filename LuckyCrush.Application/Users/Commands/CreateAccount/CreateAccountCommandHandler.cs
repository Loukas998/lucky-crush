using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using LuckyCrush.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Commands.CreateAccount;

public class CreateAccountCommandHandler(ILogger<CreateAccountCommandHandler> logger,
    IAccountRepository accountRepository, IFileService fileService)
    : IRequestHandler<CreateAccountCommand, Result<IEnumerable<IdentityError>>>
{
    public async Task<Result<IEnumerable<IdentityError>>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new account");

        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
        };
        user.Profile = new Domain.Entities.Account.Profile
        {
            UserId = user.Id,
            ProfileImage = request.ProfileImage.Length > 0 ?
                await fileService.SaveBytesImage(request.ProfileImage, "Images/ProfileImage")
                : "",
            BoostersUsed = 0,
            CurrentLevel = 1,
            LevelsCompleted = 0,
            StarsCollected = 0,
            TotalCoinsEarned = 0,
        };
        user.Balance = new Balance
        {
            UserId = user.Id,
            Coins = 1000,
            Diamonds = 1000,
            Hearts = 1000
        };
        user.Setting = new Setting
        {
            UserId = user.Id,
            BackgroundMusic = true,
            Language = "en",
            PushNotification = true,
            SoundEffect = true
        };

        var created = await accountRepository.RegisterGoogle(user);
        return Result<IEnumerable<IdentityError>>.Success(created);
    }
}
