using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banken2
{
    class Customer //The class Customer
    {
        public string Namn { get; set; }
        public int Saldo { get; set; }
        public Customer()
        {
        }
        public Customer(string name, int Saldo) //konstruktorn.
        {
            this.Namn = name;
            this.Saldo = Saldo;
        }
        public string ShowCustomer {get { return Namn + "  " + Saldo; } }
        public void SetCustomerInfo(string row)
        {
            string[] items = row.Split(',');
            this.Namn = items.First();
            this.Saldo = int.Parse(items.Last());
        }
        public string GetCustomerInfo()
        {
            return Namn + ',' + Saldo;  
        }
    }
}
