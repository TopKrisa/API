using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabgc.Persistence
{
    public class DbInitializer
    {
        public async static void Initialize(ZabgcDbContext context)
        {
            await context.Database.EnsureCreatedAsync();
        }
    }
}
