using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    internal class Coin
    {
        private readonly CoinType _type;
        public Coin(CoinType type)
        {
            _type = type;
        }

        public int Value => GetValue();

        private int GetValue()
        {
            switch (_type)
            {
                case CoinType.Ten:
                    return 10;
                case CoinType.Hundred:
                    return 100;
                case CoinType.FiveHundred:
                    return 500;
                default:
                    throw new NotSupportedException();
            }
        }
    }

    internal enum CoinType
    {
        Ten,
        Hundred,
        FiveHundred,
    }
}

