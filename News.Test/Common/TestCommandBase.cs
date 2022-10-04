using News.Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zabgc.Persistence;

namespace Zabgc.Test.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ZabgcDbContext Context;

        public TestCommandBase()
        {
            Context = NewsContextFactory.Create();
        }


        public void Dispose()
        {
            NewsContextFactory.Destroy(Context);
        }
    }
}
