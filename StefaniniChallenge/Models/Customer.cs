using StefaniniChallenge.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniChallenge.Models
{
    class Customer
    {
        public EnumTypes _type { get; private set; }
        string _cpf;
        string _name;
        int _totalPurchases;

        public Customer(int type, string cpf, string name, int totalPurchases)
        {
            _cpf = cpf;
            _name = name;
            _totalPurchases = totalPurchases;
            _type = EnumTypes.Customer;
        }
    }
}
