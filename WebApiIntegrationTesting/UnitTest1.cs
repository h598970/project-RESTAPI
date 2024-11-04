using DAT250_REST.Controllers;
using DAT250_REST.Data;
using DAT250_REST.Models;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace WebApiIntegrationTesting
{
    public class PollsControllerTesting
    {
        
        //public async Task GetPolls_WhenCalled_ReturnsPollsListAsync()
        //{

        //    //Arrange
        //    var options = new DbContextOptionsBuilder<AppDBContext>()
        //        .UseInMemoryDatabase(databaseName: "TestPollsDatabase")
        //        .Options;

        //    using var context = new AppDBContext(options);
        //    context.Polls.Add(new Poll
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Question = "What is your favorite programming language?",
        //        PublishedAt = DateTime.Now.AddDays(-1),
        //        ValidUntil = DateTime.Now.AddDays(6),
        //        Options = new List<VoteOption>()
        //    });
        //    context.Polls.Add(new Poll
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Question = "Which frontend framework do you prefer?",
        //        PublishedAt = DateTime.Now.AddDays(-2),
        //        ValidUntil = DateTime.Now.AddDays(5),
        //        Options = new List<VoteOption>()
        //    });

        //    var mockSet = Substitute.For<DbSet<Poll>, IQueryable<Poll>>();
        //    ((IQueryable<Poll>)mockSet).Provider.Returns(mockData.Provider);
        //    ((IQueryable<Poll>)mockSet).Expression.Returns(mockData.Expression);
        //    ((IQueryable<Poll>)mockSet).ElementType.Returns(mockData.ElementType);
        //    ((IQueryable<Poll>)mockSet).GetEnumerator().Returns(mockData.GetEnumerator());

        //    var mockContext = Substitute.For<AppDBContext>();
        //    mockContext.Polls.Returns(mockSet);
        //    var controller = new PollsController(mockContext);

        //    //Act

        //    var result = (await controller.GetPolls()).Value;
        //    //Assert

        //    Assert.NotNull(result);
        //    Assert.Equal(2, result.Count());
        //}
    }
}