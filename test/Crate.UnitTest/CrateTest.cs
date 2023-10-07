using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Crate;
using TestWebHost;

namespace Von.Crate.UnitTest
{
    internal class TestApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddCrate();
            });
            return base.CreateHost(builder);
        }
    }
    
    public class CrateTest
    {

        private TestApplication app;

        [SetUp]
        public void Setup()
        {
            app = new TestApplication();
        }

        [Test]
        public void CanIAccessCrate()
        {
            
            var client = app.CreateDefaultClient();
            var result = client.GetStringAsync("api/name").Result;
            Assert.AreEqual("Crocodile Wallet", result);
        }
    }
}