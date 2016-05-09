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
        GMap.NET.WindowsForms.GMapOverlay overlayOne;
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

            overlayOne = new GMap.NET.WindowsForms.GMapOverlay( "markers");
            overlayOne.Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new GMap.NET.PointLatLng(40, -83), GMarkerGoogleType.green));
            myMap.Overlays.Add(overlayOne);


    }


}
}
