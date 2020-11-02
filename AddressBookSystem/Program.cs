using System;

namespace AddressBookSystem
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("Hello Welcome to Address Book System...!");
            ///Created the object of address book class
            AddressBook addressBook = new AddressBook();
            while (true)
            {
                Console.WriteLine("Choose An Option \n1.Add New Contact \n2.Edit Existing Contact \n3.Delete A Contact \n4.View A Contact \n5.Exit Application\n");
                choice = Convert.ToInt32(Console.ReadLine());
                ///Switch to give choices to user.
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter First Name :");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name :");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Enter Address :");
                        string address = Console.ReadLine();
                        Console.WriteLine("Enter City :");
                        string city = Console.ReadLine();
                        Console.WriteLine("Enter State :");
                        string state = Console.ReadLine();
                        Console.WriteLine("Enter Email :");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter Zip :");
                        int zip = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Phone Number :");
                        long phoneNumber = Convert.ToInt64(Console.ReadLine());
                        addressBook.AddContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                        break;
                    case 2:
                        Console.WriteLine("Enter First Name Of Contact To Edit :");
                        string nameToEdit = Console.ReadLine();
                        addressBook.EditContact(nameToEdit);
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name Of Contact To Delete :");
                        string nameToDelete = Console.ReadLine();
                        addressBook.DeleteContact(nameToDelete);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name Of Contact To View :");
                        string nameToDisplay = Console.ReadLine();
                        addressBook.DisplayContact(nameToDisplay);
                        break;
                    case 5:
                        Console.WriteLine("Thank You For Using Address Book System.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter Valid Choice.");
                        break;
                }
            }
        }
    }
}
