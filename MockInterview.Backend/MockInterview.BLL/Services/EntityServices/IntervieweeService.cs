using Microsoft.EntityFrameworkCore;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Repositories.interfaces;

namespace MockInterview.BLL.Services.EntityServices;

public class IntervieweeService : EntityServiceBase<Interviewee, IRepositoryBase<Interviewee>>, IIntervieweeService
{
    public IntervieweeService(IRepositoryBase<Interviewee> entityRepository) : base(entityRepository)
    {
    }

    public override async Task<Interviewee?> GetByIdAsync(long id)
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