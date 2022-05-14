using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.IO;

namespace TestWebRequest
{
    [TestClass]
    public class WebServiceUnitTest
    {
        private static readonly HttpClient client = new HttpClient();

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            client.BaseAddress = new Uri("http://www.google.com");
        }

        [TestMethod]
        public async Task WebServiceResponseSuccess()
        {
            var response = await client.GetAsync("/");

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task WebServiceResponseContainsKeyword()
        {
            var response = await client.GetAsync("/");

            var stream = response.Content.ReadAsStream();

            var text = new StreamReader(stream).ReadToEnd();

            StringAssert.Contains(text.ToLower(), "google");
        }
    }
}