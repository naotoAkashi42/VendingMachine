using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class VendingMachine
    {
        public VendingMachine(int stockCount)
        {
            InitDrinkStocks(stockCount);
            InitCoinStocks();

        }
        private Stock<Drink> _quantityOfCoke = new Stock<Drink>();
        private Stock<Drink> _quantityOfDietCoke = new Stock<Drink>(); // ダイエットコーラの在庫数
        private Stock<Drink> _quantityOfTea = new Stock<Drink>();// お茶の在庫数
        private Stock<Coin> _numberOf100Yen = new Stock<Coin>(); // 100円玉の在庫
        private Charge _charge = new Charge(); // お釣り

        private void InitDrinkStocks(int stockCount)
        {
            for (var count = 0; count < stockCount; count++)
            {
                _quantityOfCoke.Add(new Drink(DrinkType.Coke));
                _quantityOfDietCoke.Add(new Drink(DrinkType.DietCoke));
                _quantityOfTea.Add(new Drink(DrinkType.Tea));
            }
        }

        private void InitCoinStocks()
        {
            for (var count = 0; count < 10; count++)
            {
                _numberOf100Yen.Add(new Coin(CoinType.Hundred));
            }
        }

        internal Drink Buy(Coin inputCoint, DrinkType type)
        {
            var input = inputCoint.Value;
            // 100円と500円だけ受け付ける
            if (!CanExcept(inputCoint))
            {
                _charge.Add(input);
                return null;
            }
            if (!HasStock(inputCoint.Value, type))
            {
                _charge.Add(input);
                return null;
            }

            // 釣り銭不足
            if (input == 500 && _numberOf100Yen.StockCount < 4)
            {
                _charge.Add(input);
                return null;
            }

            if (input == 100)
            {
                // 100円玉を釣り銭に使える
                _numberOf100Yen.Add(new Coin(CoinType.Hundred));
            }
            else if (input == 500)
            {
                // 400円のお釣り
                _charge.Add(input - 100);
                // 100円玉を釣り銭に使える
                for (var count = 0; count < 4; count++)
                {
                    _numberOf100Yen.Take();
                }
            }

            return Get(type);
        }

        private Drink Get(DrinkType type)
        {
            switch (type)
            {
                case DrinkType.Coke:
                    return _quantityOfCoke.Take();
                case DrinkType.DietCoke:
                    return _quantityOfDietCoke.Take();
                case DrinkType.Tea:
                    return _quantityOfTea.Take();
                default:
                    throw new NotSupportedException();
            }
        }

        private bool HasStock(int input, DrinkType type)
        {
            switch (type)
            {
                case DrinkType.Coke:
                    return _quantityOfCoke.IsOutOfStock();
                case DrinkType.DietCoke:
                    return _quantityOfDietCoke.IsOutOfStock();
                case DrinkType.Tea:
                    return _quantityOfTea.IsOutOfStock();
                default: throw new NotSupportedException();
            }
        }

        private bool IsEnoughCharge(int input)
        {
            return _charge.Amount > input;
        }

        private bool CanExcept(Coin input)
        {
            return input.Value == 500 || input.Value == 100;
        }

        /**
         * お釣りを取り出す.
         *
         * @return お釣りの金額
         */
        public int refund()
        {
            return _charge.Refund();
        }
    }
}
