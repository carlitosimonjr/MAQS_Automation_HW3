using CognizantSoftvision.Maqs.BaseWebServiceTest;
using CognizantSoftvision.Maqs.Utilities.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using WebServiceModel;
using HttpClientFactory = CognizantSoftvision.Maqs.BaseWebServiceTest.HttpClientFactory;

namespace Tests
{
    /// <summary>
    /// Simple web service test class using VS unit
    /// </summary>
    [TestClass]
    public class WebServiceTestVSUnit : BaseWebServiceTest
    {

        /// <summary>
        /// Get all products in json
        /// </summary>
        [TestMethod]
        public void GetAllProductsJson()
        {
            this.ManagerStore.AddOrOverride(new WebServiceDriverManager(() =>
            {
                HttpClient client = HttpClientFactory.GetClient(
                    new Uri(Config.GetValueForSection(ConfigSection.WebServiceMaqs, "WebServiceUri")), WebServiceConfig.GetWebServiceTimeout());
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Auth", "AuthKey");
                return client;
            }, this.TestObject));

            var response = this.WebServiceDriver.Get<Product[]>("/api/XML_JSON/GetAllProducts", "application/json", false);

            Assert.AreEqual("Tomato Soup", response[0].Name, "Wrong product");
        }
    }
}
