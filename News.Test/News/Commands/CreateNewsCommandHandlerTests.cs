using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Zabgc.Application.News.Commands.CreateNews;
using Zabgc.Test.Common;

namespace Zabgc.Test.News.Commands
{
    public class CreateNewsCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateNewsCommandHandler_Sucess()
        {
            //Arrange
            var handler = new CreateNewsCommandHandler(Context);
            var newsName = "News name";
            var newsDescription = "News Desc";
            var newsMessage = "News Message";
            var newsPosterUrl = "News Message";

            //Act

            var newsId = await handler.Handle(new CreateNewsCommand
            {
                Name = newsName,
                Description = newsDescription,
                Message = newsMessage,
                PosterUrl = newsPosterUrl
            }, CancellationToken.None);

            //Assert
            Assert.NotNull(
               await  Context.News.SingleOrDefaultAsync(news=> news.Id==newsId && news.Name ==newsName &&
                news.Description == newsDescription && news.Message == newsMessage && news.PosterUrl == newsPosterUrl));
        }
    }
}
