using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabgc.Application.News.Queries.GetNoteDetails
{
    public class GetNewsDetailsQuery : IRequest<NewsDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
