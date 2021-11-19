using StefaniniChallenge.Enums;
using System.Collections.Generic;

namespace StefaniniChallenge.Models
{
    class Salesman
    {
        public EnumTypes _type { get; private set; }
        public int _salesmanId { get; private set; }
        public string _name { get; private set; }
        public double _salary { get; private set; }

        public Salesman(int salesmanId, string name, double salary)
        {
            _salesmanId = salesmanId;
            _name = name;
            _salary = salary;
            _type = EnumTypes.Salesman;
        }

        public double TotalSales(List<Sale> sales)
        {
            double totalPrice = 0.0;
            foreach (Sale sale in sales)
            {
                totalPrice += sale.TotalPrice();
            }
            return totalPrice;
        }
    }
}
