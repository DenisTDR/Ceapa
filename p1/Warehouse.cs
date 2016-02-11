using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1
{
    public class Warehouse
    {
        public int Id { get; private set; }
        public Point Location { get; set; }

        public List<int> Products { get; set; }

        public Warehouse(int id)
        {
            Id = id;
        }
    }
}
