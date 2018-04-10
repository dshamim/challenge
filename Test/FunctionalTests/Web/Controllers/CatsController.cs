using System;
using System.Threading.Tasks;
using App.Models;
using Newtonsoft.Json;
using Xunit;

namespace FunctionalTests.Web.Controllers
{
    public class CatsController : BaseWebTest
    {
        [Fact]
        public async Task CatsController_Index_CatsList()
        {
            var response = await _client.GetAsync("/Cats");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CatViewModel>(stringResponse);

            Assert.True(model.Cats.Count > 0);
        }
    }
}
