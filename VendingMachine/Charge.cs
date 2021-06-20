using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    internal class Charge
    {
        private int _amount;
        public int Amount => _amount;
        public void Add(int input)
        {
            _amount += input;
        }

        public void Minus(int value)
        {
            _amount = -value;
        }

        public int Refund()
        {
            _amount = 0;
            return _amount;
        }
    }
}
