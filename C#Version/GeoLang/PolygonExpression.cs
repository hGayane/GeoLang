using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GeoLang
{
    public class PolygonExpression : Expression
    {
        private Canvas canvas;
        private List<double> pointData;
        public PolygonExpression(string tokenString, Canvas canvas)
        {
            this.canvas = canvas;
            this.pointData = this.ParseString(tokenString);
        }
        private List<double> ParseString(string tokenString)
        {
            var pointData = new List<double>();
            if (tokenString != null)
            {
                var arr = tokenString.Split(null);
                if (arr.Length > 1)
                {
                    for (int i = 1; i < arr.Length; i++)
                    {
                        string pointDataString = arr[i];
                        if (pointDataString != null)
                        {
                            var pointsDataArr = pointDataString.Split(null);
                            if (pointsDataArr != null)
                            {
                                foreach (var pointStr in pointsDataArr)
                                {
                                    if (pointStr != null)
                                    {
                                        var pointDataArr = pointStr.Split(',');
                                        if (pointDataArr.Count() > 1)
                                        {
                                            double.TryParse(pointDataArr[0], out double x);
                                            double.TryParse(pointDataArr[1], out double y);
                                            pointData.Add(x);
                                            pointData.Add(y);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return pointData;
        }
        public override void Eval()
        {
            List<Point> points = new List<Point>();
            var fill = new SolidColorBrush();
            fill.Color = Colors.Red;
            var border = new SolidColorBrush { Color = Colors.Black };
            var polygon = new Polygon();
            polygon.Fill = fill;
            polygon.Stroke = border;
            for(int i = 0; i < this.pointData.Count();i+=2)
            {
                var x = this.pointData[i];
                var y = this.pointData[i + 1];
                var point = new Point(x, y);
                points.Add(point);

            }
            polygon.Points = new PointCollection(points);
            this.canvas.Children.Add(polygon);
        }
    }
}
