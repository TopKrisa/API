using AutoMapper;
using System;
using Zabgc.Application.Comment.Commands.CreateComment;
using Zabgc.Application.Comment.Commands.UpdateComment;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.WebApi.Models.Comment
{
    public class UpdateCommentDto : IMapWith<UpdateCommentCommand>
    {
        public Guid UserId { get; set; }
        public string Message { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCommentDto, CreateCommentCommand>()
                .ForMember(comm => comm.UserId,
                opt => opt.MapFrom(comm => comm.UserId))
                .ForMember(comm => comm.Message,
                opt => opt.MapFrom(comm => comm.Message));
        }
    }
}
