using StefaniniChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniChallenge.Services
{
    class SalesmanServices
    {
        Salesman _salesman;
        List<Salesman> _salesmen;

        public SalesmanServices(Salesman salesman)
        {
            _salesman = salesman;
        }

        public SalesmanServices(List<Salesman> salesmen)
        {
            _salesmen = salesmen;
        }       

        public string WorstSalesmanName(List<Sale> sales)
        {
            IEnumerable<Sale> salesmanSales = sales.Where(x => x._salesmanName == _salesmen.First()._name);
            string worstSalesmanName = _salesmen.First()._name;
            double worstSalesmanValue = 0.0;

            foreach (Sale sale in salesmanSales)
            {
                worstSalesmanValue += sale.TotalPrice();
            }
            foreach (Salesman salesman in _salesmen)
            {
                salesmanSales = sales.Where(x => x._salesmanName == salesman._name);
                double totalPrice = salesman.TotalSales(salesmanSales.ToList());

                if (totalPrice < worstSalesmanValue)
                {
                    worstSalesmanValue = totalPrice;
                    worstSalesmanName = salesman._name;
                }
            }
            return worstSalesmanName;
        }
    }
}
