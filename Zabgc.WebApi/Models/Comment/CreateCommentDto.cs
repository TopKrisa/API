using AutoMapper;
using System;
using Zabgc.Application.Comment.Commands.CreateComment;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.WebApi.Models.Comment
{
    public class CreateCommentDto : IMapWith<CreateCommentCommand>
    {
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public Zabgc.Domain.Models.Comment Answer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCommentDto, CreateCommentCommand>()
                .ForMember(comm => comm.UserId,
                opt => opt.MapFrom(comm => comm.UserId))
                .ForMember(comm => comm.Message,
                opt => opt.MapFrom(comm => comm.Message))
                .ForMember(comm => comm.Answer,
                opt => opt.MapFrom(comm => comm.Answer));
        }
    }
}
