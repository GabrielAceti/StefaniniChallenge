using StefaniniChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniChallenge.Services
{
    class SaleServices
    {
        List<Sale> _sales;
        Sale _sale;

        public SaleServices(List<Sale> sales)
        {
            _sales = sales;
        }

        public SaleServices(Sale sale)
        {
            _sale = sale;
        }

        public int MostExpensiveSale()
        {
            double mostExpensiveSale = 0.0;
            int? mostExpensiveSaleId = null;
            foreach (Sale sale in _sales)
            {
                double totalPrice = sale.TotalPrice();

                if (totalPrice > mostExpensiveSale)
                {
                    mostExpensiveSale = totalPrice;
                    mostExpensiveSaleId = sale._saleId;
                }
            }
            return (int)mostExpensiveSaleId;
        }
    }
}
