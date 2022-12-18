using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Exceptions;
using MockInterview.Core.Models.Common;
using MockInterview.Core.Models.Entities;
using MockInterview.Core.Models.Enums;
using MockInterview.DAL.Repositories.Interfaces;

namespace MockInterview.BLL.Services.EntityServices;

/// <summary>
/// Provides methods to manipulate interview details
/// </summary>
public class InterviewService : EntityServiceBase<Interview, IRepositoryBase<Interview>>, IInterviewService
{
    public InterviewService(IRepositoryBase<Interview> entityRepository) : base(entityRepository)
    {
    }

    public override async Task<Interview?> CreateAsync(Interview interview, bool saveChanges = true)
    {
        if (interview == null)
            throw new ArgumentException(nameof(interview));

        return await Task.Run(async () =>
        {
            interview.Id = 0;
            interview.Status = InterviewStatuses.Created.ToString();
            EntityRepository.Create(interview);
            return saveChanges ? await EntityRepository.SaveChangesAsync() ? interview : throw new InvalidOperationException() : interview;
        });
    }

    public override async Task<bool> UpdateAsync(long id, Interview model, bool saveChanges = true)
    {
        if (id <= 0 || model == null || id != model.Id)
            throw new ArgumentException();

        return await Task.Run(async () =>
        {
            var foundInterview = await GetByIdAsync(id) ?? throw new EntryNotFoundException(typeof(Interview).FullName);
            foundInterview.InterviewTime = model.InterviewTime;
            foundInterview.Status = model.Status;
            EntityRepository.Update(model);
            return !saveChanges || await EntityRepository.SaveChangesAsync();
        });
    }
}