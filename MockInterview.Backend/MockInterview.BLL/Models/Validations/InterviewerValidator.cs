using FluentValidation;
using MockInterview.Core.Models.Entities;

namespace MockInterview.BLL.Models.Validations;

public class InterviewerValidator :  AbstractValidator<Interviewer>
{
    public InterviewerValidator()
    {
        
    }
}