using MediatR;
using System;
using Zabgc.Domain.Models;

namespace Zabgc.Application.Page.Commands.UpdatePage
{
    public class UpdatePageCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid PageCategoryId { get; set; }
    }
}
