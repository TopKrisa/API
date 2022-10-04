using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.Questions.Commands.UpdateQuestion;

namespace Zabgc.WebApi.Models.Question
{
    public class UpdateQuestionDto : IMapWith<UpdateQuestionCommand>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public string Answer { get; set; }
        public string AdminName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateQuestionDto, UpdateQuestionCommand>()
                .ForMember(q => q.Id,
                opt => opt.MapFrom(q => q.Id))
                .ForMember(q => q.Message,
                opt => opt.MapFrom(q => q.Message))
                .ForMember(q => q.Name,
                opt => opt.MapFrom(q => q.Name))
                .ForMember(q => q.Answer,
                opt => opt.MapFrom(q => q.Answer))
                .ForMember(q => q.AdminName,
                opt => opt.MapFrom(q => q.AdminName));
        }
    }
}
