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

        Distance _distance;
        Duration _duration;
        LatLng _endLocation;
        string _instructions;
        LatLng _startLocation;

        #endregion

        #region Properties

        public Distance Distance {
            get {
                return _distance ?? (_distance = new Distance());
            }
            set {
                _distance = value;
            }
        }
        public Duration Duration {
            get {
                return _duration ?? (_duration = new Duration());
            }
            set {
                _duration = value;
            }
        }

        public LatLng EndLocation {
            get {
                return _endLocation ?? (_endLocation = new LatLng());
            }
            set {
                _endLocation = value;
            }
        }

        public string Instructions { get; set; }

        public LatLng StartLocation {
            get{
                return _startLocation ?? (_startLocation = new LatLng());
            }
            set {
                _startLocation = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {

            var result = new Dictionary<string, object>();

            if (_distance != null) result["distance"] = _distance.ToScriptData();
            if (_duration != null) result["duration"] = _duration.ToScriptData();
            if (_endLocation != null) result["end_location"] = _endLocation.ToScriptData();
            if (this.Instructions != null) result["instructions"] = this.Instructions;
            if (_startLocation != null) result["start_location"] = _startLocation.ToScriptData();

            return result;
        }
        #endregion
    }
}
