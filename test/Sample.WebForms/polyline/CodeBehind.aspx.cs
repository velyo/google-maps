using System;
using System.Collections.Generic;
using System.Web.UI;
using Velyo.Google.Maps;

namespace Artem.GoogleMap.WebSite.Polylines
{
    public partial class CodeBehind : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GoogleMap1.Polylines.Add(new GooglePolyline
            {
                Clickable = true,
                OnClientClick = "handleClick",
                StrokeWeight = 10,
                Path = new List<LatLng>{
                    new LatLng(42.14304, 24.74967),
                    new LatLng(42.69649, 23.32601)
                }
            });
        }
    }
}