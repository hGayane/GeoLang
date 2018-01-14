using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLang
{
    public static class Constants
    {
        public static class Regex
        {
            public const string Function = @"^s*func.*$";
            public const string Polygon = @"^s*@.*$";
        }
    }
}
