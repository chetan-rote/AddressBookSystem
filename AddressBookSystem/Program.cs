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
            Console.WriteLine("Hello Welcome to Address Book System...!");
            ///Created the object of address book class
            AddressBook addressBook = new AddressBook();
            ///Reads details from user.
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
            Console.WriteLine("Enter Zip :");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Phone Number :");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Email :");
            string email = Console.ReadLine();
            addressBook.AddContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            addressBook.DisplayContact();
            addressBook.EditContact(firstName);
            addressBook.DisplayContact();
        }
    }
}
