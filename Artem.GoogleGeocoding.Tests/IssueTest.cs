using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artem.Google.Net;

namespace Artem.GoogleGeocoding.Tests {
    
    [TestClass]
    public class IssueTest {

        #region Construct /////////////////////////////////////////////////////////////////////////

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Issue13038() {

            GeoRequest request = new GeoRequest("Yonge and Finch Toronto Canada Ontario");
            GeoResponse response = request.GetResponse();
            Assert.AreEqual(GeoStatus.OK, response.Status);
        }

        [TestMethod]
        public void Issue11898() {

            GeoRequest request = new GeoRequest("4 Cassia Ct, Alice Springs, Northern Territory, 0870, Australia");
            GeoResponse response = request.GetResponse();
            Assert.AreEqual(GeoStatus.OK, response.Status);
        }
        #endregion
    }
}
