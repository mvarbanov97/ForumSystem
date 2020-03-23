using ForumSystem.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ForumSystem.Services.Tests
{
    public class HomePageTests
    {
        [Fact]
        public async Task HomePageShouldHaveH1Title()
        {
            var serverFactory = new WebApplicationFactory<Startup>();

            var client = serverFactory.CreateClient(); // Return HttpClient that can make requests to the server

            var response = await client.GetAsync("/");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<h1", responseAsString);
        }
    }
}
