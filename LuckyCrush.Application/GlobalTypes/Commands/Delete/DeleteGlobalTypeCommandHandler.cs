using AutoMapper;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.GlobalTypes.Commands.Delete;

public class DeleteGlobalTypeCommandHandler(ILogger<DeleteGlobalTypeCommandHandler> logger, IMapper mapper,
    IGlobalTypeRepository globalTypeRepository) : IRequestHandler<DeleteGlobalTypeCommand, Result>
{
    public async Task<Result> Handle(DeleteGlobalTypeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(@"Deleting type with id: {GlobalTypeId}: ", request.GlobalTypeId);
        var existing = await globalTypeRepository.FindByIdAsync(request.GlobalTypeId);
        if (existing == null)
        {
            return Result.Failure("Type not found");
        }

        await globalTypeRepository.DeleteAsync(existing);
        return Result.Success();
    }
}
