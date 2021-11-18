using StefaniniChallenge.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniChallenge.Models
{
    class Salesman
    {
        public EnumTypes _type { get; private set; }
        int _salesmanId;
        string _name;
        double _salary;

        public Salesman(int salesmanId, string name, double salary)
        {
            _salesmanId = salesmanId;
            _name = name;
            _salary = salary;
            _type = EnumTypes.Salesman;
        }
    }
}
