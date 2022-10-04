using System;
using Microsoft.EntityFrameworkCore;
using Zabgc.Persistence;

namespace News.Test.Common
{
    public class NewsContextFactory
    {
        public static Guid NewsIdForDelete = Guid.NewGuid();
        public static Guid NewsIdForUpdate = Guid.NewGuid();
        public static Guid NewsCatId = Guid.NewGuid();

        public static ZabgcDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ZabgcDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ZabgcDbContext(options);
            context.Database.EnsureCreated();
            context.NewsCategories.Add(
                new Zabgc.Domain.Models.NewsCategory
                {
                    Description = "Desc1",
                    Id = NewsCatId,
                    Name = "Name1"
                }
                );
            context.News.AddRange(
                new Zabgc.Domain.Models.News
                {
                    Id = Guid.Parse("BCC85F9A-F384-4F06-8C11-9E5979E13B2D"),
                    CreationDate = DateTime.Today,
                    Description = "Desc1",
                    EditionDate = null,
                    Message = "Message1",
                    PosterUrl = "URL1",
                    Name = "Name1",
                    NewsCategoryId = NewsCatId
                }
                );
            context.SaveChanges();
            return context;
        }
        public static void Destroy(ZabgcDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
