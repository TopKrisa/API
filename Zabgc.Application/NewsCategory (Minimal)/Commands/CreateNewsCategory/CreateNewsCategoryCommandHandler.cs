using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zabgc.Application.Interfaces;

namespace Zabgc.Application.NewsCategory.Commands.CreateNewsCategory
{
    public class CreateNewsCategoryCommandHandler : IRequestHandler<CreateNewsCategoryCommand, Guid>
    {
        public readonly IZabgcDbContext _dbContext;


        public CreateNewsCategoryCommandHandler(IZabgcDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateNewsCategoryCommand request, CancellationToken cancellationToken)
        {
            var newsCategory = new Domain.Models.NewsCategory
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description
            };

            await _dbContext.NewsCategories.AddAsync(newsCategory, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return newsCategory.Id;
        }
    }
}
