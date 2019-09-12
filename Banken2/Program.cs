using System;
using System.Collections.Generic;
namespace Banken2
{
    class Program
    {
        static List<Customer> list = new List<Customer>();

        static void Main(string[] args)
        {
            int choice = 0;
            choice = ShowMenuItem();
            switch(choice)
            {

            }
            Customer customer = new Customer();
            Console.Write("Ange ditt namn: ");
            customer.Namn = Console.ReadLine();
            Console.Write("Ange ditt saldo: ");
            customer.Saldo = int.Parse(Console.ReadLine());
            Console.WriteLine(customer.ShowCustomer);
        }
        static int ShowMenuItem()
        {
            int choice = 0;
            Console.WriteLine("Ange vilket av följande alternativ önskar du göra");

            Console.WriteLine("1 : Lägg till en användare");
            Console.WriteLine("2 : Ta bort en användare");
            Console.WriteLine("3 : Visa alla befintliga användare");
            Console.WriteLine("4 : Visa saldo för en användare");
            Console.WriteLine("5 : Gör en insättning för en användare");
            Console.WriteLine("6 : Gör ett uttag för en användare");
            Console.WriteLine("7 : Avsluta programmet");

            Console.Write("Skriv ditt val: ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}
