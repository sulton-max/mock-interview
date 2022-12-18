using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Repositories.interfaces;

namespace MockInterview.BLL.Services.EntityServices;

public class InterviewService : EntityServiceBase<Interview, IRepositoryBase<Interview>>, IInterviewService
{
    public InterviewService(IRepositoryBase<Interview> entityRepository) : base(entityRepository)
    {
    }
}