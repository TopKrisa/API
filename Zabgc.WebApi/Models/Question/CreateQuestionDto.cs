using AutoMapper;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.Questions.Commands.CreateQuestion;

namespace Zabgc.WebApi.Models.Question
{
    public class CreateQuestionDto : IMapWith<CreateQuestionCommand>
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateQuestionDto, CreateQuestionCommand>()
                .ForMember(q => q.Name,
                opt => opt.MapFrom(q => q.Name))
                .ForMember(q => q.Message,
                opt => opt.MapFrom(q => q.Message));
        }
    }
}
