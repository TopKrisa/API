using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zabgc.Persistence;

namespace Zabgc.Test.Common
{
    public class PagesContextFactory
    {
        public static ZabgcDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ZabgcDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;
            var context = new ZabgcDbContext(options);
            context.Database.EnsureCreated();
            context.Pages
            
            context.Pages.AddRange(
                new Domain.Models.Page()
                {
                    Id = Guid.Parse("23DC8821-5798-453F-B813-3D55537C312B"),
                    Name = "Page1",
                    CreationDate = DateTime.Now,
                    PageCategoryId =
                });
        }
    }
}
