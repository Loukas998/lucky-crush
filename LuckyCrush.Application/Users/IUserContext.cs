

namespace LuckyCrush.Application.Users
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}
