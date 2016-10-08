using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Velyo.Google.Geocoding.Tests
{
    /// <summary>
    ///This is a test class for GeoRequestTest and is intended
    ///to contain all GeoRequestTest Unit Tests
    ///</summary>
    [TestClass]
    public class GeoRequestTest
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
        public void GetResponse_ReturnResult()
        {
            GeoRequest request = new GeoRequest("plovdiv bulgaria");
            GeoResponse response = request.GetResponse();

            Assert.IsNotNull(response);
        }

        public void GetResponse_ReturnResoltAsync()
        {
            //var request = new GeoRequest("plovdiv bulgaria");
            //AsyncCallback callback;
            //IAsyncResult result = request.BeginGetResponse(callback, null);
            //callback.EndInvoke(result);
            //result.AsyncWaitHandle.
        }

        /// <summary>
        /// Gets the response_ address.
        /// </summary>
        [TestMethod]
        public void GetResponse_Address()
        {
            GeoRequest request = new GeoRequest("plovdiv bulgaria");
            GeoResponse response = request.GetResponse();

            GeoLocation actual = response.Results[0].Geometry.Location;
            GeoLocation expected = new GeoLocation(42.1354079, 24.7452904);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Gets the response_ location.
        /// </summary>
        [TestMethod]
        public void GetResponse_Location()
        {
            GeoRequest request = new GeoRequest(42.1354079, 24.7452904);
            GeoResponse response = request.GetResponse();

            string actual = response.Results[0].FormattedAddress;
            string expected = @"bul. ""Hristo Botev"" 56, 4000 Plovdiv, Bulgaria";

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test GeoResponse with status <code>OK</code>.
        ///</summary>
        [TestMethod]
        public void GetResponse_Status_OK()
        {
            GeoRequest target = new GeoRequest("plovdiv bulgaria");
            GeoResponse actual = target.GetResponse();

            GeoStatus expected = GeoStatus.Ok;

            Assert.AreEqual(expected, actual.Status);
        }

        /// <summary>
        /// Test GeoResponse with status <code>ZERO_RESULTS</code>.
        /// </summary>
        [TestMethod]
        public void GetResponse_Status_BadRequest()
        {
            GeoRequest target = new GeoRequest();

            GeoStatus actual = target.GetResponse().Status;
            GeoStatus expected = GeoStatus.BadRequest;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Gets the response_ with_ street_ address.
        /// </summary>
        [TestMethod]
        public void GetResponse_With_StreetAddress()
        {
            GeoRequest request = new GeoRequest("Alice Springs, Northern Territory, 0870, Australia﻿﻿﻿﻿");
            GeoResponse response = request.GetResponse();

            Assert.AreEqual(GeoStatus.Ok, response.Status);

            request.Address = "4 Cassia Ct, Alice Springs, Northern Territory, 0870, Australia";
            response = request.GetResponse();

            Assert.AreEqual(GeoStatus.Ok, response.Status);
        }
    }
}
