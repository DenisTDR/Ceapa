using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1.Commands
{
    public class LoadCommand:Command
    {
        private readonly int _droneId;

        private readonly int _warehouseId;
        private readonly int _productType;
        private readonly int _productCount;
        private readonly char _commandChar;

        public LoadCommand(int droneId, bool load, int warehouseId, int productType, int productCount)
        {
            _droneId = droneId;
            _warehouseId = warehouseId;
            _productType = productType;
            _productCount = productCount;
            _commandChar = load ? 'L' : 'U';
        }

        public override string GetInfo()
        {
            return string.Format("{0} {1} {2} {3} {4}", _droneId, _commandChar, _warehouseId, _productType,
                _productCount);
        }
    }
}
