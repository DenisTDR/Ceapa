using System.Collections.Generic;

namespace p1
{
    public class Drone
    {
        public int Id { get; private set; }
        public List<Command> Commands { get; set; }

        public Drone(int id)
        {
            Id = id;
        }
    }
}
