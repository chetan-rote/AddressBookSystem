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
            AddressBook addressBook = new AddressBook();
            addressBook.AddContact("Kunal", "Sharma", "Dadar", " Mumbai", "Maharashtra", 400084, 9632587321, "kunal@gmail.com");
            addressBook.DisplayContact();
        }
    }
}
