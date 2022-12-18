using System.Data;
using FluentValidation;
using MockInterview.Core.Models.Entities;

namespace MockInterview.BLL.Models.Validations;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
    }
}