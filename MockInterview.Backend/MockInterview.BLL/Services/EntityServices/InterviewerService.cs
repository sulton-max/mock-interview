using Microsoft.EntityFrameworkCore;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Repositories.interfaces;

namespace MockInterview.BLL.Services.EntityServices;

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