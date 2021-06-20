using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    internal class Stock<T>
    {

        private IList<T> _stocks;

        public Stock(IList<T> stocks)
        {
            _stocks = stocks;
        }

        public IEnumerable<T> GetList()
        {
            return _stocks.ToList();
        }

        public int StockCount => _stocks.Count();

        public bool IsOutOfStock()
        {
            return _stocks.Count() == 0;
        }

        public void Add(T stock)
        {
            _stocks.Add(stock);
        }

        public T Take()
        {
            var index = _stocks.Count - 1;
            var outPut = _stocks[index];
            _stocks.RemoveAt(index);
            return outPut;
        }
    }
}
