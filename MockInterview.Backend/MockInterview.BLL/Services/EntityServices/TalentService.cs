using Microsoft.EntityFrameworkCore;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Repositories.interfaces;

namespace MockInterview.BLL.Services.EntityServices;

public class TalentService : EntityServiceBase<Talent, IRepositoryBase<Talent>>, ITalentService
{
    public TalentService(IRepositoryBase<Talent> entityRepository) : base(entityRepository)
    {
    }
}