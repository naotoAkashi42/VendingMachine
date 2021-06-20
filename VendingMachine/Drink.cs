using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class Drink
    {


        private DrinkType _kind;

        public Drink(DrinkType kind)
        {
            _kind = kind;
        }

        public DrinkType GetKind()
        {
            return _kind;
        }
    }

    public enum DrinkType
    {
        Coke = 0,
        DietCoke,
        Tea,
    }
}
