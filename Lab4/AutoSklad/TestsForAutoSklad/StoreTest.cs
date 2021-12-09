using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoSklad.Data;
using AutoSklad.Orchestrators.LocalStore.Contract;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace TestsForAutoSklad
{
    public class StoreTest
    {
        private HttpClient _client;
        private CustomWebApplicationFactory _factory;
        private const string RequestUrl = "/api/Store/banks/Stores/";

        [SetUp]
        public void SetUp()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }
        [Test]
        public async Task StoresController_GetById_ReturnsStoreModel()
        {
            var httpResponse = await _client.GetAsync($"/LocalStore/sklad/{1}/localstore/" + 1);
            
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var store = JsonConvert.DeserializeObject<AutoSklad.Orchestrators.LocalStore.Contract.LocalStore>(stringResponse);
            
            Assert.AreEqual(1, store.Id);
            Assert.AreEqual(1231, store.Count);
            Assert.AreEqual("ghfhaoirg[", store.Location);
            Assert.AreEqual("32ewknlfk;fro32", store.Naming);
        }
        [Test]
        public async Task StoresController_Add_AddsStoreToDatabase()
        {
            var Store = new AutoSklad.Orchestrators.LocalStore.Contract.LocalStore(){Id = 2, Location = "gio;hewrq;", Count = 123123, Naming = "dasfads"};
            var content = new StringContent(JsonConvert.SerializeObject(Store), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync($"/LocalStore/sklad/{1}/localstore", content);

            
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var StoreInResponse = JsonConvert.DeserializeObject<AutoSklad.Orchestrators.LocalStore.Contract.LocalStore>(stringResponse);

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<AutoSkladContext>();
                var databaseStore = await context.LocalStores.FindAsync(StoreInResponse.Id);
                Assert.AreEqual(databaseStore.Id, StoreInResponse.Id);
                Assert.AreEqual(databaseStore.Naming, StoreInResponse.Naming);
                Assert.AreEqual(databaseStore.Count, StoreInResponse.Count);
                Assert.AreEqual(databaseStore.Location, StoreInResponse.Location);
            }
        }
        [Test]
        public async Task StoresController_Update_UpdatesStoreInDatabase()
        {
            var store = new AutoSklad.Orchestrators.LocalStore.Contract.LocalStore{Id = 1, Count = 1231432};
            var content = new StringContent(await JsonConvert.SerializeObjectAsync(store), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PatchAsync($"/LocalStore/{store.Id}", content);

            httpResponse.EnsureSuccessStatusCode();
            
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<AutoSkladContext>();
                var databaseStore = await context.LocalStores.FindAsync(store.Id);
                Assert.AreEqual(store.Count, databaseStore.Count);
            }
        }

        [Test]
        public async Task BooksController_DeleteById_DeletesBookFromDatabase()
        {
            var StoreId = 1;
            var httpResponse = await _client.DeleteAsync("/LocalStore/" + StoreId);

            httpResponse.EnsureSuccessStatusCode();

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<AutoSkladContext>();

                Assert.AreEqual(0, context.LocalStores.Count());
            }
        }
    }
}