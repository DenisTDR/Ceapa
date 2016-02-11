using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1.Commands
{
    public class WaitCommand : Command
    {
        private readonly int _droneId;
        private readonly int _turns;

        public WaitCommand(int turns, int droneId)
        {
            this._turns = turns;
            this._droneId = droneId;
        }

        public override string GetInfo()
        {
            return string.Format("{0} 'W' {1}", _droneId, _turns);
        }
    }
}