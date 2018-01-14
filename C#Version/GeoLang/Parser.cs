using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GeoLang
{
    public static class Parser
    {
        private static Regex polygonRegex = new Regex(Constants.Regex.Polygon);
        private static Regex funcRegex = new Regex(Constants.Regex.Function);
        public static IEnumerable<Expression> ParseFromFile(string path,Canvas canvas)
        {
            var expressions = new List<Expression>();
            using(var streamReader = new StreamReader(path))
            {
                var line = string.Empty;
                var mode = 0;// 0 nothing to found,1 polygon 2 function
                while((line = streamReader.ReadLine()) != null)
                {
                    var match = polygonRegex.Match(line);
                    if(match.Success)
                    {
                        mode = 1;
                       var expression = new PolygonExpression(match.Value,canvas);
                       expressions.Add(expression);
                        mode = 0;
                    }
                    else 
                    {
                        match = funcRegex.Match(line);
                        if(match.Success)
                        {
                            mode = 2;
                            Console.WriteLine($"func = {match.Value}");
                        }
                    }
                }

            }
            return expressions;
        }
    }
}
