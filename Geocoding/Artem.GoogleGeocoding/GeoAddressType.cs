using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.Net {

    /// <summary>
    /// 
    /// </summary>
    public enum GeoAddressType {
        /// <summary>
        /// indicates a precise street address
        /// </summary>
        street_address,
        /// <summary>
        /// indicates a named route (such as "US 101"). 
        /// </summary>
        route,
        /// <summary>
        /// indicates a major intersection, usually of two major roads. 
        /// </summary>
        intersection,
        /// <summary>
        /// indicates a political entity. Usually, this type indicates a polygon of some civil administration. 
        /// </summary>
        political,
        /// <summary>
        /// indicates the national political entity, and is typically the highest order type returned by the Geocoder.
        /// </summary>
        country,
        /// <summary>
        /// indicates a first-order civil entity below the country level. Within the United States, these administrative levels are states. Not all nations exhibit these administrative levels. 
        /// </summary>
        administrative_area_level_1,
        /// <summary>
        /// indicates a second-order civil entity below the country level. Within the United States, these administrative levels are counties. Not all nations exhibit these administrative levels. 
        /// </summary>
        administrative_area_level_2,
        /// <summary>
        /// indicates a third-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels. 
        /// </summary>
        administrative_area_level_3,
        /// <summary>
        /// indicates a commonly-used alternative name for the entity. 
        /// </summary>
        colloquial_area,
        /// <summary>
        /// indicates an incorporated city or town political entity. 
        /// </summary>
        locality,
        /// <summary>
        /// indicates an first-order civil entity below a locality 
        /// </summary>
        sublocality,
        /// <summary>
        /// indicates a named neighborhood 
        /// </summary>
        neighborhood,
        /// <summary>
        /// indicates a named location, usually a building or collection of buildings with a common name 
        /// </summary>
        premise,
        /// <summary>
        /// indicates a first-order entity below a named location, usually a singular building within a collection of buildings with a common name 
        /// </summary>
        subpremise,
        /// <summary>
        /// indicates a postal code as used to address postal mail within the country. 
        /// </summary>
        postal_code,
        /// <summary>
        /// indicates a prominent natural feature. 
        /// </summary>
        natural_feature,
        /// <summary>
        /// indicates an airport. 
        /// </summary>
        airport,
        /// <summary>
        /// indicates a named park. 
        /// </summary>
        park,
        /// <summary>
        /// indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category such as "Empire State Building" or "Statue of Liberty." 
        /// </summary>
        point_of_interest,
        /// <summary>
        /// indicates a specific postal box. 
        /// </summary>
        post_box,
        /// <summary>
        /// indicates the precise street number. 
        /// </summary>
        street_number,
        /// <summary>
        /// indicates the floor of a building address. 
        /// </summary>
        floor,
        /// <summary>
        /// indicates the room of a building address. 
        /// </summary>
        room,

        postal_code_prefix,

        establishment
    }
}
