using MockInterview.BLL.Services.AuthenticationServices.Interfaces;
using MockInterview.BLL.Services.EntityServices;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Repositories.Interfaces;

namespace MockInterview.BLL.Services.AuthenticationServices
{
    public class UserRoleService : EntityServiceBase<UserRole, IRepositoryBase<UserRole>>, IUserRoleService
    {
        public UserRoleService(IRepositoryBase<UserRole> entityRepository) : base(entityRepository)
        {
        }

        public async Task<UserRole?> GetByNameAsync(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentNullException("name");

            return await Task.Run(() =>
            {
                 var model = EntityRepository.Get(x => x.Name == name).FirstOrDefault();
                 return model;
            });
        }
    }
}
