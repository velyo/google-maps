using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Artem.Google.UI;

namespace Artem.GoogleMap.WebSite.Models {

    /// <summary>
    /// Summary description for MarkersRepository
    /// </summary>
    [DataObject(true)]
    public class MarkersRepository {

        #region Static Methods

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IEnumerable<MarkerRecord> GetTestMarkers(int count, Bounds bounds) {

            if ((count > 0) && bounds != null) {
                var random = new Random();
                double lat, lng;
                double latSpan, lngSpan;

                for (int i = 0; i < count; i++) {
                    latSpan = bounds.NorthEast.Latitude - bounds.SouthWest.Latitude;
                    lngSpan = bounds.NorthEast.Longitude - bounds.SouthWest.Longitude;
                    lat = bounds.SouthWest.Latitude + (latSpan * random.NextDouble());
                    lng = bounds.SouthWest.Longitude + (lngSpan * random.NextDouble());
                    yield return new MarkerRecord { Lat = lat, Lng = lng, Info = "Marker #" + (i + 1) };
                }
            }
        }
        #endregion
    }
}