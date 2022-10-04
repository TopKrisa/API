using Microsoft.EntityFrameworkCore;
using System;
using Zabgc.Persistence;

namespace Zabgc.Test.Common
{
    public class NewsPapperContextFactory
    {
        public static ZabgcDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ZabgcDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;
            var context = new ZabgcDbContext(options);
            context.Database.EnsureCreated();
            context.Newspappers.AddRange(
                new Domain.Models.Newspapper()
                {
                    Id = Guid.Parse("A352074C-7605-4B8B-8C3E-BC8834413D82"),
                    Name = "NewsPapper1",
                    Date = DateTime.Now,
                    Url = "http://example.com"
                },
                new Domain.Models.Newspapper()
                {
                    Id = Guid.Parse("1E090FEA-CA41-4262-9540-B6B4C9E44CEB"),
                    Name = "NewsPapper2",
                    Date = DateTime.Now.AddDays(-3),
                    Url = "http://example.com"
                });
            context.SaveChanges();
            return context;
        }
        public static void Destroy(ZabgcDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
