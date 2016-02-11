using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p1.Commands;

namespace p1
{
    internal class Loader
    {
        public static void LoadConfig(StreamReader sr, List<Drone> drones )
        {
            var line = sr.ReadLine();
            var splitted = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Config.Rows = int.Parse(splitted[0]);
            Config.Columns = int.Parse(splitted[1]);
            Config.Drones = int.Parse(splitted[2]);
            Config.Turns = int.Parse(splitted[3]);
            Config.MaxPayload = int.Parse(splitted[4]);
            Config.ProductTypes = int.Parse(sr.ReadLine());

            line = sr.ReadLine();
            splitted = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var w = splitted.Select(int.Parse).ToList();
            Config.ProdWeights = w;

            for (int i = 0; i < Config.Drones; i++)
            {
                drones.Add(new Drone(i));
            }
        }

        public static void LoadWarehouses(StreamReader sr, List<Warehouse> list)
        {
            var nrWh = int.Parse(sr.ReadLine());
            for (var i = 0; i < nrWh; i++)
            {
                var wh = new Warehouse(i);
                var pos = sr.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                wh.Location = new Point(int.Parse(pos[0]), int.Parse(pos[1]));
                var items = sr.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var prods = items.Select(int.Parse).ToList();
                wh.Products = prods;
                list.Add(wh);
            }
        }

        public static void LoadOrders(StreamReader sr, List<Order> orders)
        {
            var nrOrders = int.Parse(sr.ReadLine());
            for (var i = 0; i < nrOrders; i++)
            {
                var order = new Order(i);
                var pos = sr.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                order.Location = new Point(int.Parse(pos[0]), int.Parse(pos[1]));
                order.TotalItems = int.Parse(sr.ReadLine());

                var readLine = sr.ReadLine();
                if (readLine != null)
                {
                    var splLine = readLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    order.Needs = new int[Config.ProductTypes].ToList();
                    for (var j = 0; j < order.TotalItems; j++)
                    {
                        order.Needs[int.Parse(splLine[j])]++;
                    }
                }
                orders.Add(order);
            }
        }

        public static void MotherOfLoad(StreamReader sr, List<Warehouse> whList, List<Order> orderList,
            List<Drone> drList)
        {
            Loader.LoadConfig(sr, drList);
            Loader.LoadWarehouses(sr, whList);
            Loader.LoadOrders(sr, orderList);
        }
    }
}
