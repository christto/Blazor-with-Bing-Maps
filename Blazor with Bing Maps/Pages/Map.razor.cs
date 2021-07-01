using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Model;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor_with_Bing_Maps.Pages
{
    public partial class Map
    {
        #region Propertys

        [Inject]
        IJSRuntime JSRuntime { get; set; }

        #endregion

        #region Methods 

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await DrawMap();
            await DrawPoint();
            await DrawPushpin();
            await DrawPolyline();
            await DrawPolygon();
        }

        public async Task DrawMap()
        {
            await JSRuntime.InvokeAsync<Task>("loadMap");
        }

        public async Task DrawPoint()
        {
            Point point = new Point()
            {
                Color = "green",
                Location = new Location(19.047292, -98.198344),
                Visible = true
            };

            await JSRuntime.InvokeAsync<Task>("addPoint", point);
        }

        public async Task DrawPushpin()
        {
            List<Pushpin> pushpins = new();
            
            Pushpin pushpin1 = new()
            {
                Icon = "./img/pin.png",
                Color = "white",
                Location = new Location(19.017197837435784, -98.26093103918575),
                Title = "Pin 1",
                SubTitle = "Location",
                Text = "19.017197837435784, -98.26093103918575",
                Visible = true
            };

            Pushpin pushpin2 = new()
            {
                Icon = "./img/pin.png",
                Color = "white",
                Location = new Location(19.019221, -98.259706),
                Title = "Pin 2",
                SubTitle = "Location",
                Text = "19.019221, -98.259706",
                Visible = true
            };

            pushpins.Add(pushpin1);
            pushpins.Add(pushpin2);

            foreach (var point in pushpins)
                await JSRuntime.InvokeAsync<Task>("addPushpin", point);
        }

        public async Task DrawPolyline()
        {
            Polyline polyline = new();
            List<(Location[] line, string color)> lines = new();

            Location[] polyline1 = {
                new Location(19.018508, -98.261933),
                new Location(19.017586, -98.261536),
                new Location(19.017392, -98.261903),
                new Location(19.017229, -98.262312),
                new Location(19.017120, -98.262367),
                new Location(19.016459, -98.262333),
                new Location(19.016078, -98.261365),
                new Location(19.014791, -98.260799),
                new Location(19.014984, -98.260383),
                new Location(19.015575, -98.260652)
            };

            Location[] polyline2 = {
                new Location(19.018883, -98.261360),
                new Location(19.018785, -98.261635),
                new Location(19.018434, -98.261458),
                new Location(19.018085, -98.261344),
                new Location(19.017776, -98.261186),
                new Location(19.017436, -98.261058),
                new Location(19.017369, -98.261009),
                new Location(19.017138, -98.260911),
                new Location(19.017231, -98.260663),
                new Location(19.017350, -98.260332),
                new Location(19.017362, -98.260232),
                new Location(19.017367, -98.260089),
                new Location(19.017391, -98.260001),
                new Location(19.017542, -98.259878),
                new Location(19.017798, -98.259758),
                new Location(19.017918, -98.259617),
                new Location(19.018124, -98.259551),
            };

            lines.Add((polyline1, "rgba(255, 0, 8, 0.55)"));
            lines.Add((polyline2, "rgba(13, 0, 255, 0.55)"));

            foreach (var (line, color) in lines)
            {
                polyline.Line = line;
                polyline.Options = new PolylineOptions
                {
                    StrokeColor = color,
                    StrokeThickness = 4,
                    StrokeDashArray = "0"
                };

                await JSRuntime.InvokeAsync<Task>("addPolyline", polyline);
            }
        }

        public async Task DrawPolygon()
        {
            Polygon polygon = new();
            List<(Location[] area, string color, string rgba)> areas = new();

            List<Location> polygon1 = new();

            polygon1.Add(new Location(19.018403, -98.262978));//inicio
            polygon1.Add(new Location(19.018378, -98.262270));
            polygon1.Add(new Location(19.018925, -98.261766));
            polygon1.Add(new Location(19.019417, -98.261361));
            polygon1.Add(new Location(19.017126, -98.258345));
            polygon1.Add(new Location(19.013278, -98.261666));
            polygon1.Add(new Location(19.014170, -98.262266));
            polygon1.Add(new Location(19.015225, -98.262599));
            polygon1.Add(new Location(19.017171, -98.262642));
            polygon1.Add(new Location(19.018403, -98.262978));

            List<Location> polygon2 = new();

            polygon2.Add(new Location(19.019809, -98.261231));//inicio
            polygon2.Add(new Location(19.020478, -98.260850));
            polygon2.Add(new Location(19.020284, -98.260499));
            polygon2.Add(new Location(19.020221, -98.260442));
            polygon2.Add(new Location(19.019776, -98.259452));
            polygon2.Add(new Location(19.019967, -98.258178));
            polygon2.Add(new Location(19.018567, -98.257663));
            polygon2.Add(new Location(19.018488, -98.257703));
            polygon2.Add(new Location(19.017827, -98.258346));
            polygon2.Add(new Location(19.017837, -98.258395));
            polygon2.Add(new Location(19.019809, -98.261231));

            areas.Add((polygon1.ToArray(), "blue", "rgba(1, 41, 255, 0.25)"));
            areas.Add((polygon2.ToArray(), "red", "rgba(255, 0, 8, 0.25)"));

            foreach (var (area, color, rgba) in areas)
            {
                polygon.Shape = area;
                polygon.Options = new PolygonOptions
                {
                    FillColor = rgba,
                    StrokeColor = color,
                    StrokeThickness = 2
                };

                await JSRuntime.InvokeAsync<Task>("addPolygon", polygon);
            }
        }

        #endregion
    }
}
