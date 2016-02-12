using System;
using System.Collections.Generic;
using System.Drawing;
using p1.Commands;

namespace p1
{
    public class Drone
    {
        public int Id { get; private set; }
        public List<Command> Commands { get; set; }

        public Point Location { get; set; }

        public int timpTrecut = 0;
        public bool Available { get { return timpTrecut < Config.Turns; } }

        public Drone(int id)
        {
            Commands = new List<Command>();
            Id = id;
        }

        public int crtWeight = 0;
        public bool AddCommand(Command cmd )
        {

            if (cmd is LoadCommand)
            {
                var lc = (LoadCommand) cmd;
                var dist = (int) Math.Ceiling(Program.Warehouses[lc.WarehouseId].Location.DistTo(this.Location));

                this.Location = Program.Warehouses[lc.WarehouseId].Location;
                var crtReqTime = dist + 1;
                if (crtReqTime + timpTrecut > Config.Turns)
                {
                    return false;
                }
                timpTrecut += crtReqTime;
                crtWeight += lc.ProductCount*Config.ProdWeights[lc.ProductType];

            }
            else if (cmd is DeliverCommand)
            {
                var dc = (DeliverCommand)cmd;
                var dist = (int)Math.Ceiling(Program.Orders[dc.OrderId].Location.DistTo(this.Location));

                this.Location = Program.Orders[dc.OrderId].Location;
                var crtReqTime = dist + 1;

                if (crtReqTime + timpTrecut > Config.Turns)
                {
                    return false;
                }
                timpTrecut += crtReqTime;
                crtWeight -= lc.ProductCount * Config.ProdWeights[lc.ProductType];
            }

            Commands.Add(cmd);
            return true;
        }

        public void UnloadToOrder(int orderId)
        {
            var x = Commands.Count;
            for (int i = 0; i < x; i++)
            {
                if (Commands[i] is LoadCommand)
                    AddCommand(((LoadCommand) Commands[i]).MakeDeliverCommand(orderId));
            }
        }
    }
}
