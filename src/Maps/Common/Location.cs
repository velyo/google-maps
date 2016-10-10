using System.Collections.Generic;
using System.ComponentModel;

namespace Velyo.Google.Maps
{
    /// <summary>
    /// 
    /// </summary>
    public class Location : IScriptDataConverter
    {
        private LatLng _point;


        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        public Location() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        public Location(string address)
        {
            Address = address;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lng">The LNG.</param>
        public Location(double lat, double lng)
        {
            Point = new LatLng(lat, lng);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="point">The point.</param>
        public Location(LatLng point)
        {
            Point = point;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="source">The source.</param>
        public Location(Location source)
        {
            Address = source.Address;
            Point = source.Point;
        }


        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the point.
        /// </summary>
        /// <value>The point.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public LatLng Point
        {
            get { return _point ?? (_point = new LatLng()); }
            set { _point = value; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value
        {
            get { return (object)_point ?? (object)Address; }
        }


        /// <summary>
        /// Froms the script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static Location FromScriptData(object scriptObject)
        {
            var data = scriptObject as IDictionary<string, object>;
            if (data != null)
            {
                var location = new Location();
                object value;
                if (data.TryGetValue("location", out value))
                {
                    if (value is IDictionary<string, object>)
                        location.Point = LatLng.FromScriptData(value);
                    else
                        location.Address = value as string;
                }
                return location;
            }
            return null;
        }

        /// <summary>
        /// Parses the specified pair.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public static Location Parse(string point)
        {
            return new Location(point);
        }

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData()
        {
            return new Dictionary<string, object> {
                {"location", (_point != null) ? (object)_point.ToScriptData() : Address }
            };
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return (_point != null)
                ? string.Format("{0},{1}", JsUtility.Encode(_point.Latitude), JsUtility.Encode(_point.Longitude))
                : Address;
        }
    }
}
