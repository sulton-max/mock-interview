using AutoMapper;
using MockInterview.BLL.Models.DTOs;
using MockInterview.Core.Models.Entities;

namespace MockInterview.API.MapperProfiles;

public class CommonProfile : Profile
{
    public CommonProfile()
    {
        
        #region Common entities

        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        
        CreateMap<Contact, ContactDto>();
        CreateMap<ContactDto, Contact>();
        
        CreateMap<Talent, TalentDto>();
        CreateMap<TalentDto, Talent>();
        
        CreateMap<Interviewee, IntervieweeDto>();
        CreateMap<IntervieweeDto, Interviewee>();
        
        CreateMap<Interviewer, InterviewerDto>();
        CreateMap<InterviewerDto, Interviewer>();
        
        CreateMap<SelectionItem, SelectionItemDto>();
        CreateMap<SelectionItemDto, SelectionItem>();
            
        CreateMap<Interview, InterviewDto>();
        CreateMap<InterviewDto, Interview>();
        
        #endregion
    }
}