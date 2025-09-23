using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Tasks.Commands.TrackUserProgress;

public class TrackUserProgressCommandHandler(ILogger<TrackUserProgressCommandHandler> logger, ITaskRepository taskRepository,
    IAccountRepository accountRepository) : IRequestHandler<TrackUserProgressCommand>
{
    public async Task Handle(TrackUserProgressCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Tracking user order");

        var user = await accountRepository.GetUserWithProgressAsync(request.UserId);
        if (user == null)
        {

        }

        var task = await taskRepository.GetTaskWithGoals(request.TaskId); // could be removed and count only on goal
        if (task == null)
        {

        }

        var goal = task.Goals.FirstOrDefault(t => t.Id == request.GoalId);
        if (goal == null)
        {

        }

        var totalUserAmountOfGoal = user.Progresses
            .Where(p => p.GoalId == request.GoalId)
            .ToList()
            .Sum(a => a.Amount);

        user.Progresses.Add(new Domain.Entities.Tasks.Progress
        {
            UserId = request.UserId,
            GoalId = request.GoalId,
            Amount = request.Amount,
            Completed = goal.Target == totalUserAmountOfGoal
        });

        await taskRepository.SaveChangesAsync();
    }
}
