using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
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
}