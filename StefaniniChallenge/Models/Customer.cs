using StefaniniChallenge.Enums;

namespace StefaniniChallenge.Models
{
    class Customer
    {
        public EnumTypes _type { get; private set; }
        public string _cpf { get; private set; }
        public string _name { get; private set; }
        public int _totalPurchases { get; private set; }

        public Customer(string cpf, string name, int totalPurchases)
        {
            _cpf = cpf;
            _name = name;
            _totalPurchases = totalPurchases;
            _type = EnumTypes.Customer;
        }
    }
}
