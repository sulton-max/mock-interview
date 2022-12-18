using System.Data;
using FluentValidation;
using MockInterview.Core.Extensions;
using MockInterview.Core.Models.Entities;
using MockInterview.Core.Models.Enums;

namespace MockInterview.BLL.Models.Validations;

public class InterviewValidator : AbstractValidator<Interview>
{
    public InterviewValidator()
    {
        RuleFor(x => x.InterviewTime).GreaterThan(DateTime.UtcNow);
        RuleFor(x => x.Status)
            .Custom((value, context) =>
            {
                try
                {
                    var test = value.ToEnum<InterviewStatuses>();
                }
                catch
                {
                    context.AddFailure("Invalid enum value");
                }
            });
    }
}