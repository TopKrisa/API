using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.Questions.Queries.GetQuestionList
{
    public class QuestionLookupDto : IMapWith<Domain.Models.Question>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string User { get; set; }
        public bool Activity { get; set; }
        public string Answer { get; set; }
        public string AdminName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Question, QuestionLookupDto>()
                .ForMember(q => q.Message,
                opt => opt.MapFrom(q => q.Message))
                .ForMember(q => q.User,
                opt => opt.MapFrom(q => q.User))
                .ForMember(q => q.Answer,
                opt => opt.MapFrom(q => q.Answer))
                .ForMember(q => q.Activity,
                opt => opt.MapFrom(q => q.Activity))
                .ForMember(q => q.AdminName,
                opt => opt.MapFrom(q => q.AdminName));
        }
    }
}
