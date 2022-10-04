using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.Comment.Queries.GetCommentList
{
    public class CommentLookupDto : IMapWith<Domain.Models.Comment>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Domain.Models.Comment Answer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Comment, CommentLookupDto>()
                .ForMember(comment => comment.Message,
                opt => opt.MapFrom(comment => comment.Message))
                .ForMember(comment => comment.Answer,
                opt => opt.MapFrom(comment => comment.Answer));
        }
    }
}
