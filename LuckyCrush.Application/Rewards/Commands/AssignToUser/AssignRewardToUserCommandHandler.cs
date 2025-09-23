using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rewards.Commands.AssignToUser;

public class AssignRewardToUserCommandHandler(ILogger<AssignRewardToUserCommandHandler> logger,
    IAccountRepository accountRepository, ITaskRepository taskRepository, IRewardRepository rewardRepository)
    : IRequestHandler<AssignRewardToUserCommand>
{
    public async Task Handle(AssignRewardToUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning reward to user");

        var user = await accountRepository.GetUserWithProgressAsync(request.UserId);
        if (user == null)
        {

        }

        var task = await taskRepository.GetTaskWithGoals(request.TaskId);
        if (task == null)
        {

        }

        var reward = await taskRepository.FindByIdAsync(request.RewardId);
        if (reward == null)
        {

        }

        int taskTarget = task.Goals.Sum(g => g.Target);
        int sum = user.Progresses
            .Where(p => task.Goals.Select(g => g.Id).Contains(p.GoalId))
            .Sum(p => p.Amount);

        if (sum >= taskTarget)
        {
            user.Rewards.Add(new Domain.Entities.Tasks.Reward
            {
                Amount = taskTarget,
                TaskId = request.TaskId,
                TypeId = reward.TypeId,
            });

            await taskRepository.SaveChangesAsync();
        }
        else
        {
            logger.LogInformation(
                "User {UserId} has not completed task {TaskId}: {Progress}/{Target}",
                user.Id, task.Id, sum, taskTarget);
        }
    }
}
