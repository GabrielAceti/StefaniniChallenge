using StefaniniChallenge.Enums;
using System.Collections.Generic;

namespace StefaniniChallenge.Models
{
    class Sale
    {
        public EnumTypes _type { get; private set; }        
        public int _saleId { get; private set; }
        public List<Item> _itemList { get; private set; }
        public string _salesmanName { get; private set; }

        public Sale(int saleId, List<Item> itemList, string salesmanName)
        {
            _saleId = saleId;
            _itemList = itemList;
            _salesmanName = salesmanName;
            _type = EnumTypes.Sale;
        }

        public double TotalPrice()
        {
            double totalPrice = 0.0;
            foreach (Item item in _itemList)
            {
                totalPrice += item.TotalPrice();
            }
            return totalPrice;
        }
    }
}
