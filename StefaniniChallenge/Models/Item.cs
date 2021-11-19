using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniChallenge.Models
{
    class Item
    {
        int _itemId;
        int _numberOfItems;
        double _itemPrice;

        public Item(int itemId, int numberOfItems, double itemPrice)
        {
            _itemId = itemId;
            _numberOfItems = numberOfItems;
            _itemPrice = itemPrice;
        }

        public double TotalPrice()
        {
            return (double)_numberOfItems * _itemPrice;
        }
    }
}
