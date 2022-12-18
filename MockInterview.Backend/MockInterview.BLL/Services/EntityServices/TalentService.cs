using Microsoft.EntityFrameworkCore;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Repositories.Interfaces;

namespace MockInterview.BLL.Services.EntityServices;

/// <summary>
/// Provides methods to manipulate talent details
/// </summary>
public class TalentService : EntityServiceBase<Talent, IRepositoryBase<Talent>>, ITalentService
{
    public TalentService(IRepositoryBase<Talent> entityRepository) : base(entityRepository)
    {
    }
}