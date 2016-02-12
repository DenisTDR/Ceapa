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

        public readonly int WarehouseId;
        public readonly int ProductType;
        public readonly int ProductCount;
        private readonly char _commandChar;

        public LoadCommand(int droneId, bool load, int warehouseId, int productType, int productCount)
        {
            _droneId = droneId;
            WarehouseId = warehouseId;
            ProductType = productType;
            ProductCount = productCount;
            _commandChar = load ? 'L' : 'U';
        }

        public override string GetInfo()
        {
            return string.Format("{0} {1} {2} {3} {4}", _droneId, _commandChar, WarehouseId, ProductType,
                ProductCount);
        }
        
    }
}
