using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Class for containing directions event data.
    /// </summary>
    public class DirectionsChangedEventArgs : EventArgs, IScriptDataConverter {

        #region Static Fields

        //public static readonly DirectionsChangedEventArgs Empty = new DirectionsChangedEventArgs();

        #endregion

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static DirectionsChangedEventArgs FromScriptData(IDictionary<string, object> data) {

            var args = new DirectionsChangedEventArgs();
            object value;

            if (data.TryGetValue("distance", out value))
                args.Distance = Distance.FromScriptData(value as IDictionary<string, object>);
            if (data.TryGetValue("duration", out value))
                args.Duration = Duration.FromScriptData(value as IDictionary<string, object>);
            if (data.TryGetValue("end_address", out value)) args.EndAddress = value as string;
            if (data.TryGetValue("end_location", out value))
                args.EndLocation = LatLng.FromScriptData(value as IDictionary<string, object>);
            if (data.TryGetValue("start_address", out value)) args.StartAddress = value as string;
            if (data.TryGetValue("start_location", out value))
                args.StartLocation = LatLng.FromScriptData(value as IDictionary<string, object>);

            if (data.TryGetValue("steps", out value)) {
                object[] items = value as object[];
                if (items != null) {
                    var list = new List<DirectionsStep>();
                    for (int i = 0; i < items.Length; i++) {
                        var item = DirectionsStep.FromScriptData(items[i] as IDictionary<string, object>);
                        if (item != null) list.Add(item);
                    }
                    args.Steps = list.ToArray();
                }
            }

            return args;
        }
        #endregion

        #region Properties

        /// <summary>
        /// A representation of distance as a numeric value and a display string.
        /// The total distance covered. This property may be undefined as the distance may be unknown.
        /// </summary>
        /// <value>The distance.</value>
        public Distance Distance { get; set; }

        /// <summary>
        /// A representation of duration as a numeric value and a display string.
        /// The total duration. This property may be undefined as the duration may be unknown.
        /// </summary>
        /// <value>The duration.</value>
        public Duration Duration { get; set; }

        /// <summary>
        /// The address of the destination.
        /// </summary>
        /// <value>The end address.</value>
        public string EndAddress { get; set; }

        /// <summary>
        /// The DirectionsService calculates directions between locations by using the nearest transportation option (usually a road) at the start and end locations. 
        /// EndLocation indicates the actual geocoded destination, which may be different than the end_location of the last step if, for example, the road is not near the destination of this leg.
        /// </summary>
        /// <value>The end location.</value>
        public LatLng EndLocation { get; set; }

        /// <summary>
        /// The address of the origin.
        /// </summary>
        /// <value>The start address.</value>
        public string StartAddress { get; set; }

        /// <summary>
        /// The DirectionsService calculates directions between locations by using the nearest transportation option (usually a road) at the start and end locations. 
        /// StartLocation indicates the actual geocoded origin, which may be different than the start_location of the first step if, for example, the road is not near the origin of this leg.
        /// </summary>
        /// <value>The start location.</value>
        public LatLng StartLocation { get; set; }

        /// <summary>
        /// An array of DirectionsSteps, each of which contains information about the individual steps in this leg.
        /// </summary>
        /// <value>The steps.</value>
        public DirectionsStep[] Steps { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {
            throw new NotImplementedException();
        }
        #endregion
    }
}
