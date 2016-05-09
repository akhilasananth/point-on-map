using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;

namespace MapsTest
{
    public partial class Form1 : Form
    {
        static GMap.NET.PointLatLng start = new GMap.NET.PointLatLng(40, -83);
        static GMap.NET.PointLatLng end = new GMap.NET.PointLatLng(37, -115);


        public Form1()
        {

            InitializeComponent();

            var myMap = gMapControl1;
            myMap.SetPositionByKeywords("USA");
            myMap.MapProvider = GMap.NET.MapProviders.GMapProviders.BingMap;
            myMap.MinZoom = 3;
            myMap.MaxZoom = 17;
            myMap.Zoom = 4;
            myMap.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;

            //Puts points on the map
            GMap.NET.WindowsForms.GMapOverlay overlayOne = new GMap.NET.WindowsForms.GMapOverlay("markers");
            overlayOne.Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerGoogle(start, GMarkerGoogleType.green));
            overlayOne.Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerGoogle(end, GMarkerGoogleType.green));
            myMap.Overlays.Add(overlayOne);

            //Connects two points on the map
            GMap.NET.MapRoute route = GMap.NET.MapProviders.BingMapProvider.Instance.GetRoute(start, end, false, false, 15);
            GMap.NET.WindowsForms.GMapRoute r = new GMap.NET.WindowsForms.GMapRoute(route.Points, "My route");

            GMap.NET.WindowsForms.GMapOverlay routesOverlay = new GMap.NET.WindowsForms.GMapOverlay("routes");
            routesOverlay.Routes.Add(r);
            myMap.Overlays.Add(routesOverlay);
        }


    }
}
