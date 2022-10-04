using System;
using MediatR;
using Zabgc.Domain.Models;

namespace Zabgc.Application.News.Commands.CreateNews
{
    public class CreateNewsCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid NewsCategoryId { get; set; }
        public string Name { get; set; }
        public string PosterUrl { get; set; }
        public string Description { get; set; }
        public string Message { get; set; } 
    }
}
