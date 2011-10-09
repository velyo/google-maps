using Artem.Google.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Artem.GoogleGeocoding.Tests {


    /// <summary>
    ///This is a test class for GeoRequestTest and is intended
    ///to contain all GeoRequestTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GeoRequestTest {

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

        /// <summary>
        /// Gets the response_ address.
        /// </summary>
        [TestMethod]
        public void GetResponse_Address() {

            GeoRequest request = new GeoRequest("plovdiv bulgaria");
            GeoResponse response = request.GetResponse();

            GeoLocation actual = response.Results[0].Geometry.Location;
            GeoLocation expected = new GeoLocation(42.1438409, 24.7495615);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Gets the response_ location.
        /// </summary>
        [TestMethod]
        public void GetResponse_Location() {

            GeoRequest request = new GeoRequest(42.1438409, 24.7495615);
            GeoResponse response = request.GetResponse();

            string actual = response.Results[0].FormattedAddress;
            string expected = "ul. Gen. Gurko 13, Plovdiv, Bulgaria";

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test GeoResponse with status <code>OK</code>.
        ///</summary>
        [TestMethod]
        public void GetResponse_Status_OK() {

            GeoRequest target = new GeoRequest("plovdiv bulgaria");
            GeoResponse actual = target.GetResponse();
            GeoStatus expected = GeoStatus.OK;
            Assert.AreEqual(expected, actual.Status);
        }

        /// <summary>
        /// Test GeoResponse with status <code>ZERO_RESULTS</code>.
        /// </summary>
        [TestMethod]
        public void GetResponse_Status_ZERO_RESULTS() {

            GeoRequest target = new GeoRequest();
            GeoStatus actual = target.GetResponse().Status;
            GeoStatus expected = GeoStatus.ZERO_RESULTS;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Gets the response_ with_ street_ address.
        /// </summary>
        [TestMethod]
        public void GetResponse_With_Street_Address() {

            GeoRequest request = new GeoRequest("Alice Springs, Northern Territory, 0870, Australia﻿﻿﻿﻿");
            GeoResponse response = request.GetResponse();

            Assert.AreEqual(GeoStatus.OK, response.Status);

            request.Address = "4 Cassia Ct, Alice Springs, Northern Territory, 0870, Australia";
            response = request.GetResponse();

            Assert.AreEqual(GeoStatus.OK, response.Status);

        }
        #endregion
    }
}
