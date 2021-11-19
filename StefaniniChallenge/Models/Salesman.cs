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
    }
}
