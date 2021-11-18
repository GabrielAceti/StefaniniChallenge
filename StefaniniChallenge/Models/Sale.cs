using StefaniniChallenge.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniChallenge.Models
{
    class Sale
    {
        public EnumTypes _type { get; private set; }        
        int _saleId;
        List<Product> _product = new List<Product>();
        string _salesmanName;

        public Sale(int saleId, List<Product> product, string salesmanName)
        {
            _saleId = saleId;
            _product = product;
            _salesmanName = salesmanName;
            _type = EnumTypes.Sale;
        }
    }
}
