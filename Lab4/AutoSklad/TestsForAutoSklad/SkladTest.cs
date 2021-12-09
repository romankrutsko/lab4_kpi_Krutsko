using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoSklad.Data;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace TestsForAutoSklad
{
    [TestFixture]
    public class SkladTest
    {
        private HttpClient _client;
        private CustomWebApplicationFactory _factory;
        private const string RequestUrl = "/api/GlobalSklad/";

        [SetUp]
        public void SetUp()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }
        [Test]
        public async Task SkladsController_GetById_ReturnsSkladModel()
        {
            var httpResponse = await _client.GetAsync(RequestUrl + 1);
            
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var sklad = JsonConvert.DeserializeObject<AutoSklad.Orchestrators.GlobalSklad.Contract.GlobalSklad>(stringResponse);
            
            Assert.AreEqual(1, sklad.Id);
            Assert.AreEqual(1233143, sklad.Count);
            Assert.AreEqual("fafsfqfewq", sklad.Description);
            Assert.AreEqual("ewrweqrwdf", sklad.Location);
        }
        [Test]
        public async Task skladsController_Add_AddsskladToDatabase()
        {
            var sklad = new AutoSklad.Orchestrators.GlobalSklad.Contract.GlobalSklad(){Count = 12948, Location = "Twoewrwew", Description = "31231w231", NameOfThing = "dkefhqfwe"};
            var content = new StringContent(JsonConvert.SerializeObject(sklad), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync(RequestUrl + 1, content);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var skladInResponse = JsonConvert.DeserializeObject<AutoSklad.Orchestrators.GlobalSklad.Contract.GlobalSklad>(stringResponse);

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<AutoSkladContext>();
                var databasesklad = await context.Sklads.FindAsync(skladInResponse.Id);
                Assert.AreEqual(databasesklad.Id, skladInResponse.Id);
                Assert.AreEqual(databasesklad.Count, skladInResponse.Count);
                Assert.AreEqual(databasesklad.Location, skladInResponse.Location);
                Assert.AreEqual(databasesklad.NameOfThing, databasesklad.NameOfThing);
            }
        }
        [Test]
        public async Task skladsController_Update_UpdatesskladInDatabase()
        {
            var sklad = new AutoSklad.Orchestrators.GlobalSklad.Contract.GlobalSklad{Id = 1, Count = 1843};
            var content = new StringContent(await JsonConvert.SerializeObjectAsync(sklad), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PatchAsync($"/api/GlobalSklad/{sklad.Id}", content);

            httpResponse.EnsureSuccessStatusCode();
            
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<AutoSkladContext>();
                var databasesklad = await context.Sklads.FindAsync(sklad.Id);
                Assert.AreEqual(sklad.Id, databasesklad.Id);
            }
        }
        [Test]
        public async Task BooksController_DeleteById_DeletesBookFromDatabase()
        {
            var skladId = 1;
            var httpResponse = await _client.DeleteAsync(RequestUrl + skladId);

            httpResponse.EnsureSuccessStatusCode();
            
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<AutoSkladContext>();
                
                Assert.AreEqual(0, context.Sklads.Count());
            }
        }
    }
}