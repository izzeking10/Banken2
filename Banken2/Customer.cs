using System;
using System.Collections.Generic;
using System.Text;

namespace Banken2
{
    class Customer
    {
        public string Namn { get; set; }
        public int Saldo { get; set; }
        public string ShowCustomer {get { return Namn + Saldo; } }

    }
}
