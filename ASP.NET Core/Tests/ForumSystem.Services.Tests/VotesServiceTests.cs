using ForumSystem.Data;
using ForumSystem.Data.Models;
using ForumSystem.Data.Repositories;
using ForumSystem.Services.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ForumSystem.Services.Tests
{
    public class VotesServiceTests
    {
        [Fact]
        public async Task TwoDownVotesShouldCountOnce()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MemoryDb");

            var repository = new EfRepository<Vote>(new ApplicationDbContext(options.Options));
            var service = new VotesService(repository);

            // voting 100 times with first User
            for (int i = 0; i < 100; i++)
            {
                await service.VoteAsync(1, "1", false); // down vote
            }

            // voting 100 times with second User
            for (int i = 0; i < 100; i++)
            {
                await service.VoteAsync(1, "2", false); // down vote
            }

            var votesCount = service.GetVotes(1);

            Assert.Equal(-2, votesCount);
        }
    }
}
