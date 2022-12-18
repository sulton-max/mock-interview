using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Repositories.Interfaces;

namespace MockInterview.BLL.Services.EntityServices;

/// <summary>
/// Provides methods to manipulate contact information
/// </summary>
public class ContactService : EntityServiceBase<Contact, IRepositoryBase<Contact>>, IContactService
{
    public ContactService(IRepositoryBase<Contact> entityRepository) : base(entityRepository)
    {
    }
}