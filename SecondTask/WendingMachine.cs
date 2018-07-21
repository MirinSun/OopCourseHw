using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    class WendingMachine
    {
        public int Balance;
        public GoodsRepository Goods;

        public int ClearBalance()
        {
            int oldBalance = Balance;
            Balance = 0;
            return oldBalance;
        }

        public void AddBalance(int amount)
        {
            if (amount < 0)
                throw new Exception("Попытка внести отрицательную сумму");

            Balance += amount;
        }

        public void ApplyOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException("order", "");
            if (Balance < order.GetTotalPrice()) throw new InvalidOperationException("");

            Balance -= order.GetTotalPrice();
            order.GrabeGoods();
        }

        public Good[] GetProductList()
        {
            return Goods.GetAvialableGoods();
        }

        public Good GetProduct(string name)
        {
            return Goods.GetProduct(name);
        }
    }
}
