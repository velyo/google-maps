using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;
using System.Drawing;

namespace Artem.GoogleMap.WebSite.Polygons {

    public partial class CodeBehind : Page {

        #region Methods

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            var circle = new GoogleCircle {
                Center = new LatLng(42.1229, 24.7879),
                Radius = 200000
            };
            var polygon = new GooglePolygon {
                FillColor = Color.Red,
                FillOpacity = .5F,
                StrokeColor = Color.Black,
                StrokeWeight = 5,
                Paths = new List<LatLng> { 
                    new LatLng(37.97918, 23.716647),
                    new LatLng(41.036501, 28.984895),
                    new LatLng(44.447924, 26.097879),
                    new LatLng(44.802416, 20.465601),
                    new LatLng(42.002411, 21.436097),
                    new LatLng(37.97918, 23.716647),
                    new LatLng(37.97918, 23.716647)
                }
            };
            var rectangle = new GoogleRectangle {
                FillColor = Color.Green,
                Bounds = new Bounds {
                    SouthWest = new LatLng(44.802416, 20.465601),
                    NorthEast = new LatLng(37.97918, 23.716647)
                }
            };
            GoogleMap1.Overlays.Add(circle);            
            GoogleMap1.Overlays.Add(polygon);
            GoogleMap1.Overlays.Add(rectangle);
        }
        #endregion
    }
}