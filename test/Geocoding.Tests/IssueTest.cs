using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Velyo.Google.Geocoding.Tests
{
    /// <summary>
    /// Unit test for project issues. Most recent first.
    /// </summary>
    [TestClass]
    public class IssueTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestMethod]
        public void Issue14376()
        {
            var request = new GeoRequest("BH5 1DP");
            var response = request.GetResponse();
            Assert.AreEqual(GeoStatus.OK, response.Status);
        }

        [TestMethod]
        public void Issue13038()
        {

            GeoRequest request = new GeoRequest("Yonge and Finch Toronto Canada Ontario");
            GeoResponse response = request.GetResponse();
            Assert.AreEqual(GeoStatus.OK, response.Status);
        }

        [TestMethod]
        public void Issue11898()
        {

            GeoRequest request = new GeoRequest("4 Cassia Ct, Alice Springs, Northern Territory, 0870, Australia");
            GeoResponse response = request.GetResponse();
            Assert.AreEqual(GeoStatus.OK, response.Status);
        }
    }
}
