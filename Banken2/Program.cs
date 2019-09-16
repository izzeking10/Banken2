using System;
using System.Collections.Generic;
namespace Banken2
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();

        static void Main(string[] args)
        {
            int choice = 0;
            choice = ShowMenuItem();
            while (choice != 7)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Du har valt att lägga till en användare");
                        AddCustomer();
                        break;
                    case 2:
                        Console.WriteLine("Du har valt att ta bort en användare");
                        break;
                    case 3:
                        Console.WriteLine("Du har valt att visa alla användare");
                        ShowAllCustomers();
                        break;
                    case 4:
                        Console.WriteLine("Du har valt att visa saldot för vald användare");
                        break;
                    case 5:
                        Console.WriteLine("Du har valt att göra en insättning för användaren");
                        break;
                    case 6:
                        Console.WriteLine("Du har valt att göra ett uttag för användaren");
                        break;
                    case 7:
                        Console.WriteLine("Du har valt att stänga av programmet");
                        System.Environment.Exit(1);
                        break;
                    default:
                        break;
                }
                choice = ShowMenuItem();
            }
        }
        static void AddCustomer()
        {
            Customer customer = new Customer();
            Console.Write("Ange ditt namn: ");
            customer.Namn = Console.ReadLine();
            Console.Write("Ange ditt saldo: ");
            customer.Saldo = int.Parse(Console.ReadLine());
            customers.Add(customer);
        }
        static void ShowAllCustomers()
        {
            foreach (Customer c in customers)
            {
                Console.WriteLine(c.ShowCustomer);
            }
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
