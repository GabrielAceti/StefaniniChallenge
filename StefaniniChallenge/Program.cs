using StefaniniChallenge.Models;
using StefaniniChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;

namespace StefaniniChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathIn = @"C:\data\in";
            string pathOut = @"C:\data\out";
            int? mostExpensiveSaleId = null;
            string worstSalesmanName = null;
            List<Customer> customers = new List<Customer>();
            List<Salesman> salesmen = new List<Salesman>();
            List<Sale> sales = new List<Sale>();
            DirectoryInfo Dir = new DirectoryInfo(pathIn);

            foreach (FileInfo file in Dir.GetFiles())
            { 
                if(file.Extension == ".txt")
                {
                    string[] lines = FileServices.ReadLines(file.FullName);

                    foreach (string line in lines)
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

                            foreach (string itemData in itemsData)
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

                    mostExpensiveSaleId = new SaleServices(sales).MostExpensiveSale();
                    worstSalesmanName = new SalesmanServices(salesmen).WorstSalesmanName(sales);
                }                       
            }

            InformationData infData = new InformationData()
            {
                TotalCustomers = customers.Count(),
                TotalSalesmen = salesmen.Count(),
                MostExpensiveSaleId = (int)mostExpensiveSaleId,
                WorstSalesman = worstSalesmanName
            };

            string json = JSONServices.JSONParse(infData) + Environment.NewLine;

            FileServices.CreateFile(json, pathOut, Dir.GetFiles()[0].Name.Split('.')[0] + ".json");
            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}
