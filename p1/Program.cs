using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p1.Commands;

namespace p1
{
    class Program
    {
        private static readonly List<Warehouse> Warehouses = new List<Warehouse>();
        private static readonly List<Order> Orders = new List<Order>();
        private static readonly List<Drone> Drones = new List<Drone>();
        static void Main(string[] args)
        {
            var sr = new StreamReader("mother_of_all_warehouses.in");
            Loader.MotherOfLoad(sr, Warehouses, Orders, Drones);




        }
    }
}
