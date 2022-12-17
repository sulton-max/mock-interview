using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Repositories.interfaces;

namespace MockInterview.BLL.Services.EntityServices;

public class ContactService : EntityServiceBase<Contact, IRepositoryBase<Contact>>, IContactService
{
    public ContactService(IRepositoryBase<Contact> entityRepository) : base(entityRepository)
    {
    }
}