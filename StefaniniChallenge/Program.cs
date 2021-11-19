using StefaniniChallenge.Models;
using StefaniniChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace StefaniniChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            List<Salesman> salesmen = new List<Salesman>();
            List<Sale> sales = new List<Sale>();
            string[] lines = FileServices.ReadLines(@"C:\data\in\teste.txt");

            foreach(string line in lines)
            {
                string[] data = line.Split('|');
                if (data[0] == "001")
                {
                    string cpf = data[1].ToString();
                    string name = data[2].ToString();
                    int totalPurchases = int.Parse(data[3]);

                    customers.Add(new Customer(cpf, name, totalPurchases));
                }
                else if (data[0] == "002")
                {
                    int salesmanId = int.Parse(data[1]);
                    string name = data[2].ToString();
                    double salary = double.Parse(data[3]);

                    salesmen.Add(new Salesman(salesmanId, name, salary));
                }
                else if (data[0] == "003")
                {
                    int saleId = int.Parse(data[1]);
                    string salesmanName = data[3].ToString();
                    List<Item> itemList = new List<Item>();

                    string[] itemsData = data[2]
                                           .Replace("[", "")
                                              .Replace("]", "")
                                                .Split(',');     
                    
                    foreach(string itemData in itemsData)
                    {
                        string[] item = itemData.Split('-');
                        int itemId = int.Parse(item[0]);
                        int numberOfItems = int.Parse(item[1]);
                        double itemPrice = double.Parse(item[2], CultureInfo.InvariantCulture);

                        itemList.Add(new Item(itemId, numberOfItems, itemPrice));
                    }

                    sales.Add(new Sale(saleId, itemList, salesmanName));
                }
            }            

            double mostExpensiveSale = 0.0;
            int? mostExpensiveSaleId = null;            
            foreach (Sale sale in sales)
            {
                double totalPrice = sale.TotalPrice();                

                if(totalPrice > mostExpensiveSale)
                {
                    mostExpensiveSale = totalPrice;
                    mostExpensiveSaleId = sale._saleId;
                }
            }            

            string worstSalesmanName = salesmen.First()._name;
            double worstSalesmanValue = 0.0;            
            IEnumerable<Sale> salesmanSales = sales.Where(x => x._salesmanName == worstSalesmanName);

            foreach (Sale sale in salesmanSales)
            {                 
                worstSalesmanValue += sale.TotalPrice();
            }

            foreach (Salesman salesman in salesmen)
            {
                salesmanSales = sales.Where(x => x._salesmanName == salesman._name);                       
                double totalPrice = salesman.TotalSales(salesmanSales.ToList());                

                if(totalPrice < worstSalesmanValue)
                {
                    worstSalesmanValue = totalPrice;
                    worstSalesmanName = salesman._name;
                }
            }

            InformationData infData = new InformationData()
            {
                TotalCustomers = customers.Count(),
                TotalSalesmen = salesmen.Count(),
                MostExpensiveSaleId = (int)mostExpensiveSaleId,
                WorstSalesman = worstSalesmanName
            };

            string teste = JSONServices.ToJSON(infData);
            Console.WriteLine(teste);
            Console.ReadLine();
        }
    }
}
