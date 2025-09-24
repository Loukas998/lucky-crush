using AutoMapper;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.GlobalTypes.Commands.Update;

public class UpdateGlobalTypeCommandHandler(ILogger<UpdateGlobalTypeCommandHandler> logger, IMapper maper,
    IGlobalTypeRepository globalTypeRepository) : IRequestHandler<UpdateGlobalTypeCommand, Result>
{
    public async Task<Result> Handle(UpdateGlobalTypeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating Global Type with id: {GlobalTypeId} with {@UpdateGlobalType}", request.GlobalTypeId, request);
        var existing = await globalTypeRepository.FindByIdAsync(request.GlobalTypeId);
        if (existing != null)
        {
            return Result.Failure("Type not found");
        }

        maper.Map(request, existing);
        await globalTypeRepository.SaveChangesAsync();
        return Result.Success();
    }
}
