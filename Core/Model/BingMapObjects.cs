using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }
    }

    public class Point
    {
        public string Color { get; set; }
        public Location Location { get; set; }
        public bool Visible { get; set; }
    }

    public class Pushpin
    {
        public string Icon { get; set; }
        public string Color { get; set; }
        public Location Location { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Text { get; set; }
        public bool Visible { get; set; }
    }

    public class PolygonOptions
    {
        public string FillColor { get; set; }
        public string StrokeColor { get; set; }
        public int StrokeThickness { get; set; }
    }

    public class Polygon
    {
        public Location[] Shape { get; set; }
        public PolygonOptions Options { get; set; }
    }

    public class PolylineOptions
    {
        public string StrokeColor { get; set; }
        public int StrokeThickness { get; set; }
        public string StrokeDashArray { get; set; }
    }

    public class Polyline
    {
        public Location[] Line { get; set; }
        public PolylineOptions Options { get; set; }
    }
}
