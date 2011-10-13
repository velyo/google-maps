using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    public class DirectionsStep : IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static DirectionsStep FromScriptData(IDictionary<string, object> data) {

            if (data != null) {
                var step = new DirectionsStep();
                object value;

                if (data.TryGetValue("distance", out value))
                    step.Distance = Distance.FromScriptData((IDictionary<string, object>)value);
                if (data.TryGetValue("duration", out value))
                    step.Duration = Duration.FromScriptData((IDictionary<string, object>)value);
                if (data.TryGetValue("end_location", out value))
                    step.EndLocation = LatLng.FromScriptData((IDictionary<string, object>)value);
                if (data.TryGetValue("instructions", out value)) step.Instructions = (string)value;
                if (data.TryGetValue("start_location", out value))
                    step.StartLocation = LatLng.FromScriptData((IDictionary<string, object>)value);

                return step;
            }
            return null;
        }
        #endregion

        #region Fields

        public Distance Distance { get; set; }
        public Duration Duration { get; set; }
        public LatLng EndLocation { get; set; }
        public string Instructions { get; set; }
        public LatLng StartLocation { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {

            var result = new Dictionary<string, object>();

            if (this.Distance != null) result["distance"] = this.Distance.ToScriptData();
            if (this.Duration != null) result["duration"] = this.Duration.ToScriptData();
            if (this.EndLocation != null) result["end_location"] = this.EndLocation.ToScriptData();
            if (this.Instructions != null) result["instructions"] = this.Instructions;
            if (this.StartLocation != null) result["start_location"] = this.StartLocation.ToScriptData();

            return result;
        }
        #endregion
    }
}
