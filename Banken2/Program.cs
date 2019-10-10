using System;
using System.IO;
using System.Collections.Generic;
namespace Banken2
{
    class Program
    {
        static List<Customer> customers = new List<Customer>(); //makes a list for customers


        static void Main(string[] args)
        {
            string filepath = @"C:\test\";
            string filename = @"datacontainer.txt";
            LoadFile(filename, filepath); //loads file and checks if there is any customers are registered and adds some if necessary
            if (customers.Count == 0)
            {
                customers.Add(new Customer("Mika", 10));
                customers.Add(new Customer("sir", 40));
            }
            int choice = 0;
            choice = ShowMenuItem(); //checks what answer the user made
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
                        RemoveCustomer();
                        break;
                    case 3:
                        Console.WriteLine("Du har valt att visa alla användare");
                        ShowAllCustomers();
                        break;
                    case 4:
                        Console.WriteLine("Du har valt att visa saldot för vald användare");
                        ShowBalance();
                        break;
                    case 5:
                        Console.WriteLine("Du har valt att göra en insättning för användaren");
                        AddToBalance();
                        break;
                    case 6:
                        Console.WriteLine("Du har valt att göra ett uttag för användaren");
                        Withdraw();
                        break;
                    case 7:
                        Console.WriteLine("Du har valt att stänga av programmet");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Du har gjort ett felaktigt val");
                        break;
                }
                choice = ShowMenuItem();
            }
            SaveToFile(filename, filepath);

        }





        static void AddCustomer() //Makes a new customer to the customer list
        {
            try { 
            Customer customer = new Customer();
            Console.Write("Ange namn: "); //asks for a name
            customer.Namn = Console.ReadLine();
            Console.Write("Ange saldo: "); //asks how much money it has
            customer.Saldo = int.Parse(Console.ReadLine());
            customers.Add(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }








        static void ShowAllCustomers() //shows all listed customers
        {
            foreach (Customer c in customers)
            {
                Console.WriteLine(c.ShowCustomer);
            }
        }







        static void SaveToFile(string filename, string filepath) //saves/overwrites customer information on a document
        {
            string f = filepath + filename; 
            if (File.Exists(f)) //checks if document alredy exists
            {
                File.Delete(f);
            }

            if (Directory.Exists(filepath) == false)  
            {
                Directory.CreateDirectory(filepath);
            }
            string appendText = "";
            foreach (Customer customer in customers)
            {
                appendText += customer.GetCustomerInfo() + Environment.NewLine;
            }
            File.AppendAllText(f, appendText);
        }







        private static void LoadFile(string filename, string filepath) //loads dokument info and puts it into list
        {
            string f = filepath + filename;
            if (File.Exists(f))
            {
                string[] rows = File.ReadAllLines(f);
                foreach (string row in rows)
                {
                    Customer customer = new Customer();
                    customer.SetCustomerInfo(row);
                    customers.Add(customer);
                }

            }
        }





        static void RemoveCustomer() //Removes selected customer from list
        {
            try { 
            int number = 1;
            foreach (Customer c in customers) //displays all the customers in list.
                {
                Console.WriteLine(number ++ + ": " + c.Namn);
            }
            int choice = 0;
            Console.Write("skriv vilken användare du vill ta bort: "); //asks which user to remove.
                choice = int.Parse(Console.ReadLine());
            customers.RemoveAt(choice - 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }






        static void ShowBalance() //shows the balance of selected customer
        {
            int number = 1;
            foreach (Customer c in customers) //displays all the customers in list.
            {
                Console.WriteLine(number++ + ": " + c.Namn);
            }
            int choice = 0;
            Console.Write("vilken användare vill du kolla?: "); //asks which user to check balance from
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine(customers[choice - 1].Saldo);
        }





        static void AddToBalance() // adds selected amount to saldo of the selected customer
        {
         
            int number = 1;
            foreach (Customer c in customers) //displays all the customers in list.
            {
                Console.WriteLine(number++ + ": " + c.ShowCustomer);
            }
            try
            {
                int choice = 0;
            Console.Write("vilken användare väljer du?: "); //asks which customer to add money to
                choice = int.Parse(Console.ReadLine());
            Console.WriteLine(customers[choice - 1].Saldo);

            int choice2 = 0;
            Console.Write("hur mycket vill du sätta in?: "); //asks how much to add to customer
                choice2 = int.Parse(Console.ReadLine());
                while (choice2 < 0)
                {
                    Console.Write("välj ett positivt tal att sätta in: ");
                    choice2 = int.Parse(Console.ReadLine());
                }
            customers[choice - 1].Saldo += choice2;
            Console.WriteLine(customers[choice - 1].ShowCustomer);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }







        static void Withdraw()
        {
            int number = 1;
            foreach (Customer c in customers) //displays all the customers in list.
            {
                Console.WriteLine(number++ + ": " + c.ShowCustomer);
            }
            try
            {
                
                int choice = 0;
                Console.Write("vilken användare väljer du?: ");   //asks for which customer to withdraw from
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine(customers[choice - 1].Saldo);
                
                int choice2 = 0;
                Console.Write("hur mycket vill du ta ut?: ");  //asks how much to take out
                choice2 = int.Parse(Console.ReadLine());
                if (choice2 < 0)
                {
                    while (choice2 < 0)
                    {
                        Console.Write("skriv ett positivt värde att ta ut: ");
                        choice2 = int.Parse(Console.ReadLine());
                    }
                }
                customers[choice - 1].Saldo -= choice2;
                Console.WriteLine(customers[choice - 1].ShowCustomer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }







        static int ShowMenuItem()
        {
            int choice = 0;
            try
            {
                //shows actions a user what actions it can do.
                Console.WriteLine("Ange vilket av följande alternativ önskar du göra");

                Console.WriteLine("1 : Lägg till en användare");
                Console.WriteLine("2 : Ta bort en användare");
                Console.WriteLine("3 : Visa alla befintliga användare");
                Console.WriteLine("4 : Visa saldo för en användare");
                Console.WriteLine("5 : Gör en insättning för en användare");
                Console.WriteLine("6 : Gör ett uttag för en användare");
                Console.WriteLine("7 : Avsluta programmet");
                //asks for a number that represent an action.
                Console.Write("Skriv ditt val: ");
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return choice;
        }
    }
}
