using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1
{
    public static class Config
    {
        public static int Rows { get; set; }
        public static int Columns { get; set; }
        public static int Drones { get; set; }
        public static int Turns { get; set; }
        public static int MaxPayload { get; set; }
        public static int ProductTypes { get; set; }
        public static List<int> ProdWeights { get; set; }

    }
}
