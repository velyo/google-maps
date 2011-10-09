using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Artem.Google.Net {

    /// <summary>
    /// 
    /// </summary>
    public class GeoRequest {

        #region Static Fields /////////////////////////////////////////////////////////////////////

        static readonly string RequestUrl = "http://maps.google.com/maps/api/geocode/json?";

        #endregion

        #region Static Methods ////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates the specified address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public static GeoRequest Create(string address) {
            return new GeoRequest(address);
        }

        /// <summary>
        /// Creates the reverse.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        public static GeoRequest CreateReverse(double latitude, double longitude) {
            return new GeoRequest(latitude, longitude);
        }

        /// <summary>
        /// Creates the reverse.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public static GeoRequest CreateReverse(GeoLocation location) {
            return new GeoRequest(location);
        }
        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// The address that you want to geocode.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a value indicates whether or not the geocoding request comes from a device with a location sensor.
        /// </summary>
        /// <value><c>true</c> if this instance is sensor; otherwise, <c>false</c>.</value>
        public bool IsSensor { get; set; }

        /// <summary>
        /// The language in which to return results. See the supported list of domain languages. 
        /// Note that we often update supported languages so this list may not be exhaustive. 
        /// If language is not supplied, the geocoder will attempt to use the native language of the domain 
        /// from which the request is sent wherever possible. 
        /// </summary>
        /// <value>The language.</value>
        public string Language { get; set; }

        /// <summary>
        /// The latitude/longitude value for which you wish to obtain the closest, human-readable address.
        /// </summary>
        /// <value>The location.</value>
        public GeoLocation Location { get; set; }

        /// <summary>
        /// The region code, specified as a ccTLD ("top-level domain") two-character value.
        /// </summary>
        /// <value>The region.</value>
        public string Region { get; set; }

        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoRequest"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        public GeoRequest(string address) {
            this.Address = address;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoRequest"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        public GeoRequest(GeoLocation location) {
            this.Location = location;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoRequest"/> class.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public GeoRequest(double latitude, double longitude) {
            this.Location = new GeoLocation(latitude, longitude);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoRequest"/> class.
        /// </summary>
        public GeoRequest() { }

        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Begins the get response.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        public IAsyncResult BeginGetResponse(AsyncCallback callback, object state) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ends the get response.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public GeoResponse EndGetResponse(IAsyncResult result) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the raw object.
        /// </summary>
        /// <returns></returns>
        protected JsonGeoData GetJsonObject() {

            StringBuilder url = new StringBuilder( GeoRequest.RequestUrl);
            
            if (this.Location != null) {
                url.AppendFormat("latlng={0}", this.Location.ToString());
            }
            else {
                url.AppendFormat("address={0}", HttpUtility.UrlEncode(this.Address));
            }
            url.AppendFormat("&sensor={0}", this.IsSensor.ToString().ToLower());
            if (!string.IsNullOrEmpty(this.Language))
                url.AppendFormat("&language={0}", HttpUtility.UrlEncode(this.Language));
            if(!string.IsNullOrEmpty(this.Region))
                url.AppendFormat("&region={0}", HttpUtility.UrlEncode(this.Region));

            WebRequest request = WebRequest.Create(url.ToString());
            string responseData;
            using (WebResponse response = request.GetResponse()) {
                using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                    responseData = reader.ReadToEnd();
                }
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<JsonGeoData>(responseData);
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <returns></returns>
        public GeoResponse GetResponse() {
            return new GeoResponse(this.GetJsonObject());
        }
        #endregion
    }
}
