using FluentValidation;
using MockInterview.Core.Models.Entities;

namespace MockInterview.BLL.Models.Validations;

public class TalentValidator: AbstractValidator<Talent>
{
    public TalentValidator()
    {
        RuleFor(x => x.Level)
            .Custom((value, context) =>
            {
           
            });

        RuleFor(x => x.Experience)
            .Custom((value, context) =>
            {
            
            });

        RuleFor(x => x.Projects).MinimumLength(2);
    }
}