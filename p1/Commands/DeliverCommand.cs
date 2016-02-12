using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1.Commands
{
    public class DeliverCommand : Command
    {
        private readonly int _droneId;

        public readonly int OrderId;
        public readonly int ProductType;
        public readonly int ProductCount;
        private readonly char _commandChar;

        public DeliverCommand(int droneId, int orderId, int productType, int productCount)
        {
            _droneId = droneId;
            OrderId = orderId;
            ProductType = productType;
            ProductCount = productCount;
            _commandChar = 'D';
        }

        public override string GetInfo()
        {
            return string.Format("{0} {1} {2} {3} {4}", _droneId, _commandChar, OrderId, ProductType,
                ProductCount);
        }
    }
}
