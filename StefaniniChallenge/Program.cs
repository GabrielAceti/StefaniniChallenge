using StefaniniChallenge.Models;
using StefaniniChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            List<Salesman> salesmen = new List<Salesman>();
            List<Sale> sale = new List<Sale>();
            string[] lines = FileServices.ReadLines(@"C:\data\in");

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
                    sale.Add(new Sale())
                }
            }
        }
    }
}
