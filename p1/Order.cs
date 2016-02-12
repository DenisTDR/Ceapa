using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1
{
    public class Order
    {
        public int Id { get; private set; }
        public Point Location { get; set; }

        public int TotalItems { get; set; } 

        public List<int> Needs { get; set; }

        public Order(int id)
        {
            Id = id;
        }

        public bool Done
        {
            get { return Needs.Sum() == 0; }
        }

        public List<Tuple<Warehouse, double>> SortedWarehouses { get; set; } 
    }
}
