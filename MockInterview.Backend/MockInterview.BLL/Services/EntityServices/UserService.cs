using Microsoft.EntityFrameworkCore;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Repositories.Interfaces;

namespace MockInterview.BLL.Services.EntityServices;

/// <summary>
/// Provides methods to manipulate system user
/// </summary>
public class UserService : EntityServiceBase<User, IRepositoryBase<User>>, IUserService
{
    public UserService(IRepositoryBase<User> entityRepository) : base(entityRepository)
    {
    }

    public override async Task<User?> GetByIdAsync(long id)
    {
        if (id <= 0)
            throw new ArgumentException();

        return await Task.Run(() =>
        {
            var model = EntityRepository.Get(x => x.Id == id).Include(x => x.Talent).Include(x => x.Talent).FirstOrDefault();
            return model;
        });
    }
}