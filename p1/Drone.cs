using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using p1.Commands;

namespace p1
{
    public class Drone
    {
        public int Id { get; private set; }
        public List<Command> Commands { get; set; }

        public Point Location { get; set; }

        public int crtTurn = 0;
        public bool Available { get { return crtTurn < Config.Turns; } }

        public Drone(int id)
        {
            Commands = new List<Command>();
            Id = id;
            Cargo = new int[Config.ProductTypes].ToList();
        }

        public List<int> Cargo { get; private set; }

        public void LoadSomething(Warehouse wh, int productType, int productCount)
        {
            Cargo[productType] += productCount;
            Commands.Add(new LoadCommand(this.Id, true, wh.Id, productType, productCount));

            var dist = wh.Location.DistTo(this.Location).Ceil();
            crtTurn += dist + 1;

            if (CurrentWeight > Config.MaxPayload || CurrentWeight < 0)
            {
                
            }
        }
       

        public void DeliverToOrder(Order order)
        {
            var loadCommands = this.Commands.Where(c => c is LoadCommand).Cast<LoadCommand>().ToList();
            foreach (var loadCommand in loadCommands)
            {
                Commands.Add(new DeliverCommand(this.Id, order.Id, loadCommand.ProductType, loadCommand.ProductCount));
                Cargo[loadCommand.ProductType] -= loadCommand.ProductCount;
            }
        }

        public int CurrentWeight
        {
            get
            {
                return Cargo.Select((t, i) => Config.ProdWeights[i]*t).Sum();
            }
        }
    }
}
