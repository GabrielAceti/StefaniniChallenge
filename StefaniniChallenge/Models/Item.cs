
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
