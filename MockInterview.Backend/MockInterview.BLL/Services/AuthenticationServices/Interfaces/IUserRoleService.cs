using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;

namespace MockInterview.BLL.Services.AuthenticationServices.Interfaces
{
    public interface IUserRoleService: IEntityServiceBase<UserRole>
    {
        Task<UserRole?> GetByNameAsync(string name);
    }
}
