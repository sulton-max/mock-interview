using Microsoft.EntityFrameworkCore;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Extensions;
using MockInterview.DAL.Models.Query;
using MockInterview.DAL.Repositories.Interfaces;

namespace MockInterview.BLL.Services.EntityServices;

/// <summary>
/// Provides methods to manipulate interviewer details
/// </summary>
public class InterviewerService : EntityServiceBase<Interviewer, IRepositoryBase<Interviewer>>, IInterviewerService
{
    public InterviewerService(IRepositoryBase<Interviewer> entityRepository) : base(entityRepository)
    {
    }
    
    public override async Task<Interviewer?> GetByIdAsync(long id)
    {
        if (id <= 0)
            throw new ArgumentException();

        return await Task.Run(() =>
        {
            var model = EntityRepository.Get(x => x.Id == id).Include(x => x.User).FirstOrDefault();
            return model;
        });
    }
}