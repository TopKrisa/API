using MediatR;
using System;
using Zabgc.Domain.Models;

namespace Zabgc.Application.News.Commands.UpdateNews
{
    public class UpdateNewsCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid NewsCategoryId { get; set; }    
        public string Name { get; set; }
        public string PosterUrl { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
    }
}
