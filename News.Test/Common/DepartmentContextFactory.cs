using Microsoft.EntityFrameworkCore;
using System;
using Zabgc.Persistence;

namespace Zabgc.Test.Common
{
    public class DepartmentContextFactory
    {
        public static ZabgcDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ZabgcDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;
            var context = new ZabgcDbContext(options);
            context.Database.EnsureCreated();
            context.Departments.AddRange(
                new Domain.Models.Department()
                {
                    Id = Guid.Parse("49FBA6A0-9093-4C02-81E1-A9002EE5B064"),
                    Name = "Dept1",
                    Text = "Text1",
                },
                new Domain.Models.Department()
                {
                    Id = Guid.Parse("DCF7DD47-5A83-42CF-B26B-EC07EB6B9B2A"),
                    Name = "Dept2",
                    Text = "Text2",
                });
            context.SaveChangesAsync();
            return context;
        }
        public static void Destroy(ZabgcDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
