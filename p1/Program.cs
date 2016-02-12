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
        public static readonly List<Warehouse> Warehouses = new List<Warehouse>();
        public static readonly List<Order> Orders = new List<Order>();
        public static readonly List<Drone> Drones = new List<Drone>();

        private static List<Command> allCommands = new List<Command>();

        private static void Main(string[] args)
        {
            DoShit("redundancy");
            DoShit("busy_day");
            DoShit("mother_of_all_warehouses");
        }

        static void DoShit(string fileName)
        {
            Console.WriteLine("\n\n\n" + fileName + ":");
            Console.Write("reading ... ");
            var sr = new StreamReader(fileName+".in");
            Loader.MotherOfLoad(sr, Warehouses, Orders, Drones);
            sr.Close();
            Console.WriteLine("Done!");

            Console.Write("Sorting ... ");
            var sortedOrders = GetOrdersSorted();
            Console.WriteLine("Done!");


            Console.Write("Processing ... ");
            foreach (var order in sortedOrders)
            {
                while (!order.Done)
                {
                    var avlbDrones = Drones.Where(x => x.Available).ToList();
                    if (avlbDrones.Count == 0)
                    {
                        return;
                    }
                    foreach (var drone in avlbDrones)
                    {

                        if (IncarcaDrona(drone, order))
                        {
                            drone.DeliverToOrder(order);

                            allCommands.AddRange(drone.Commands);

                            drone.Commands.Clear();

                            if (order.Done) break;
                        }

                    }
                }
            }
            Console.WriteLine("Done!");

            Console.Write("Writing ... ");
            var sw = new StreamWriter(fileName + ".out");
            sw.WriteLine(allCommands.Count);
            foreach (var cmd in allCommands)
            {
                sw.WriteLine(cmd.GetInfo());
            }
            sw.Close();
            Console.WriteLine("Done!");

            Console.Write("Clearing ... ");
            allCommands.Clear();
            Warehouses.Clear();
            Drones.Clear();
            Orders.Clear();
            Console.WriteLine("Done!");
        }

        private static List<Order> GetOrdersSorted()
        { 

            foreach (var order in Orders)
            {
                var whs = new List<Tuple<Warehouse, double>> ();
                foreach (var wh in Warehouses)
                {
                    var distR = wh.Location.DistTo(order.Location);
                    whs.Add(new Tuple<Warehouse, double>(wh, distR));
                }
                order.SortedWarehouses = whs.OrderBy(x => x.Item2).ToList();

            }

            var newOrdersList = new List<Order>(Orders).OrderBy(x => x.SortedWarehouses[0].Item2).ToList();


            return newOrdersList;
        }

        private static bool IncarcaDrona(Drone drona, Order order)
        {
            var stLoaded = false;
            var loadedItems = new int[Config.ProductTypes];
            var loadedWeight = 0;
            foreach (var wh in order.SortedWarehouses)
            {
                for (var i = 0; i < Config.ProductTypes; i++)
                {
                    if (order.Needs[i] == 0 || wh.Item1.Products[i] == 0) continue;

                    var maxPosCrtLoad = Math.Min(order.Needs[i], wh.Item1.Products[i]);
                    if (loadedWeight + maxPosCrtLoad*Config.ProdWeights[i] > Config.MaxPayload)
                    {
                        maxPosCrtLoad = (Config.MaxPayload - loadedWeight)/Config.ProdWeights[i];
                    }
                    if (maxPosCrtLoad == 0)
                    {
                        //drona incarcata la maxim
                        return stLoaded;
                    }
                    loadedWeight += maxPosCrtLoad*Config.ProdWeights[i];

                    //drona.Commands.Add(new LoadCommand(drona.Id, true, wh.Item1.Id, i, maxPosCrtLoad));
                    drona.LoadSomething(wh.Item1, i, maxPosCrtLoad);

                    order.Needs[i] -= maxPosCrtLoad;
                    wh.Item1.Products[i] -= maxPosCrtLoad;

                    stLoaded = true;
                }
            }
            return stLoaded;
        }

        
    }
}
