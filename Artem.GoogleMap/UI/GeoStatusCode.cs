using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Numeric equivalents for each symbolic constant are specified next to the equal sign.
    /// </summary>
    public enum GeoStatusCode {
        None = 0,
        /// <summary>
        /// No errors occurred; the address was successfully parsed and its geocode has been returned. 
        /// </summary>
        Success = 200,
        /// <summary>
        /// A directions request could not be successfully parsed. 
        /// For example, the request may have been rejected if it contained more than the maximum number of waypoints allowed. 
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// A geocoding, directions or maximum zoom level request could not be successfully processed, 
        /// yet the exact reason for the failure is not known.
        /// </summary>
        ServerError = 500,
        /// <summary>
        /// The HTTP q parameter was either missing or had no value. For geocoding requests, 
        /// this means that an empty address was specified as input. For directions requests, 
        /// this means that no query was specified in the input. 
        /// </summary>
        MissingAddress = 601,
        /// <summary>
        /// No corresponding geographic location could be found for the specified address. 
        /// This may be due to the fact that the address is relatively new, or it may be incorrect. 
        /// </summary>
        UnknownAddress = 602,
        /// <summary>
        /// The geocode for the given address or the route for the given directions query cannot be returned 
        /// due to legal or contractual reasons.
        /// </summary>
        UnavailableAddress = 603,
        /// <summary>
        /// The GDirections object could not compute directions between the points mentioned in the query. 
        /// This is usually because there is no route available between the two points, 
        /// or because we do not have data for routing in that region. 
        /// </summary>
        UnknownDirections = 604,
        /// <summary>
        /// The given key is either invalid or does not match the domain for which it was given.
        /// </summary>
        BadKey = 610,
        /// <summary>
        /// The given key has gone over the requests limit in the 24 hour period or has submitted 
        /// too many requests in too short a period of time. If you're sending multiple requests 
        /// in parallel or in a tight loop, use a timer or pause in your code to make sure 
        /// you don't send the requests too quickly. 
        /// </summary>
        TooManyQueries = 620
    }
}
