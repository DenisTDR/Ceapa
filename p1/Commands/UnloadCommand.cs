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

        private readonly int _orderId;
        private readonly int _productType;
        private readonly int _productCount;
        private readonly char _commandChar;

        public DeliverCommand(int droneId, int orderId, int productType, int productCount)
        {
            _droneId = droneId;
            _orderId = orderId;
            _productType = productType;
            _productCount = productCount;
            _commandChar = 'D';
        }

        public override string GetInfo()
        {
            return string.Format("{0} {1} {2} {3} {4}", _droneId, _commandChar, _orderId, _productType,
                _productCount);
        }
    }
}
