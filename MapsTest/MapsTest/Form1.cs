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
using System.Collections;

namespace MapsTest
{
    public partial class Form1 : Form
    {
        private List<LatLangPoint> points = new List<LatLangPoint>();
        private GMap.NET.WindowsForms.GMapOverlay overlayOne;
        private GMap.NET.WindowsForms.GMapOverlay routesOverlay;
        private GMap.NET.WindowsForms.GMapControl myMap;

        public Form1()
        {

            InitializeComponent();

            //Innitialize map image
            myMap = gMapControl1;
            myMap.SetPositionByKeywords("USA");
            myMap.MapProvider = GMap.NET.MapProviders.GMapProviders.BingMap;
            myMap.MinZoom = 3;
            myMap.MaxZoom = 17;
            myMap.Zoom = 4;
            myMap.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Button is clicked
            String inputPoint = textBox1.Text;
            String[] latLong = inputPoint.Split(',');
            try { 
            double lat = Double.Parse(latLong[0]);
            double lng = Double.Parse(latLong[1]);
            this.updateCurrentPoint(lat, lng);
            this.PlacePointOnMapAndDrawPaths();
             }
            catch(Exception entry)
            {
                Console.WriteLine("The entered value is not a number. PLease enter a valid point on the map", entry);
            }
        }

        /*
         * Plots the point entered and draws a path with the pervious point plotted
         */

        private void updateCurrentPoint(double lat, double lng)
        {
            this.points.Add(new LatLangPoint(lat, lng));
        }

        private void PlacePointOnMapAndDrawPaths()
        {
            overlayOne = new GMap.NET.WindowsForms.GMapOverlay("markers");
            routesOverlay = new GMap.NET.WindowsForms.GMapOverlay("routes");

            if (this.points.Count == 1)
            {
                LatLangPoint localPoint1 = this.points.ElementAt<LatLangPoint>(0);
                overlayOne.Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new GMap.NET.PointLatLng(localPoint1.getLat(), localPoint1.getLng()), GMarkerGoogleType.green));
                myMap.Overlays.Add(overlayOne);
            }
            if (this.points.Count > 1)
            {   
                LatLangPoint startPoint = this.points.ElementAt<LatLangPoint>(this.points.Count-2);
                LatLangPoint endPoint = this.points.ElementAt<LatLangPoint>(this.points.Count-1);
                GMap.NET.PointLatLng startMarker = new GMap.NET.PointLatLng(startPoint.getLat(), startPoint.getLng());
                GMap.NET.PointLatLng endMarker = new GMap.NET.PointLatLng(endPoint.getLat(), endPoint.getLng());
                overlayOne.Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerGoogle(endMarker, GMarkerGoogleType.green));
                myMap.Overlays.Add(overlayOne);

                //Draw path between the start and the end points
                GMap.NET.MapRoute route = GMap.NET.MapProviders.BingMapProvider.Instance.GetRoute(startMarker, endMarker, false, false, 15);
                GMap.NET.WindowsForms.GMapRoute r = new GMap.NET.WindowsForms.GMapRoute(route.Points, "My route");
                routesOverlay.Routes.Add(r);
                myMap.Overlays.Add(routesOverlay);
            }
        }
    }

    /*
     * This class represents a point on the map
     */ 
    internal class LatLangPoint
    {
        double lat;
        double lng;

        public LatLangPoint(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }

        public double getLat()
        {
            return (this.lat);
        }

        public double getLng()
        {
            return (this.lng);
        }
    }
}
