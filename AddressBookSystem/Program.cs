using System;
using System.Collections.Generic;
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
            ///Variables
            int choice, choice1;
            string bookName = "default";
            Console.WriteLine("Welcome to Address Book Program");
            ///Creates reference of AdressBook.
            AddressBook addressBook = new AddressBook();
            ///Menu for AddressBook.
            Console.WriteLine("Would You Like To \n1.Work on default AddressBook \n2.Create New AddressBook");
            choice1 = Convert.ToInt32(Console.ReadLine());
            switch (choice1)
            {
                case 1:
                    addressBook.AddAddressBook(bookName);
                    break;
                case 2:
                    Console.WriteLine("Enter Name Of New Addressbook You want to create : ");
                    bookName = Console.ReadLine();
                    addressBook.AddAddressBook(bookName);
                    break;
            }
            do
            {
                ///Menu for Contacts.
                Console.WriteLine($"Working On {bookName} AddressBook\n");
                Console.WriteLine("Choose An Option \n1.Add New Contact \n2.Edit Existing Contact \n3.Delete A Contact \n4.View A Contact \n5.View All Contacts \n6.Add New AddressBook \n7.Switch AddressBook \n8.Search Contact by city or state\n" +
                    "9.View Contacts by City or State.\n10. Count by city or state.\n11.Sort Entries by name.  \n12.Exit Application\n");
                choice = Convert.ToInt32(Console.ReadLine());
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
                        long phoneNumber = long.Parse(Console.ReadLine());
                        addressBook.AddContact(firstName, lastName, address, city, state, email, zip, phoneNumber, bookName);
                        break;
                    case 2:
                        Console.WriteLine("Enter First Name Of Contact To Edit :");
                        string nameToEdit = Console.ReadLine();
                        addressBook.EditContact(nameToEdit, bookName);
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name Of Contact To Delete :");
                        string nameToDelete = Console.ReadLine();
                        addressBook.DeleteContact(nameToDelete, bookName);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name Of Contact To View :");
                        string nameToView = Console.ReadLine();
                        addressBook.ViewContact(nameToView, bookName);
                        break;
                    case 5:
                        addressBook.ViewAllContacts(bookName);
                        break;
                    case 6:
                        Console.WriteLine("Enter Name For New AddressBook");
                        string newAddressBook = Console.ReadLine();
                        addressBook.AddAddressBook(newAddressBook);
                        Console.WriteLine("Would you like to Switch to " + newAddressBook);
                        Console.WriteLine("1.Yes \n2.No");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            bookName = newAddressBook;
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter Name Of AddressBook From Below List");
                        foreach (KeyValuePair<string, AddressBook> item in addressBook.GetAddressBook())
                        {
                            Console.WriteLine(item.Key);
                        }
                        while (true)
                        {
                            bookName = Console.ReadLine();
                            if (addressBook.GetAddressBook().ContainsKey(bookName))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No such AddressBook found. Try Again.");
                            }
                        }
                        break;
                    case 8:
                        Console.WriteLine("Would You Like To \n1.Search by city \n2.Search by state");
                        int opt = Convert.ToInt32(Console.ReadLine());
                        switch (opt)
                        {
                            case 1:
                                Console.WriteLine("Enter name of city :");
                                addressBook.SearchPersonByCity(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Enter name of state :");
                                addressBook.SearchPersonByState(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Invalid Input.Enter 1 or 2");
                                break;
                        }                        
                        break;
                    case 9:
                        Console.WriteLine("Would You Like To \n1.View by city \n2.View by state");
                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter name of city :");
                                addressBook.ViewByCity(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Enter name of state :");
                                addressBook.ViewByState(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Invalid Input.Enter 1 or 2");
                                break;
                        }                        
                        break;
                    case 10:
                        addressBook.CountPersonByCityOrState();
                        break;
                    case 11:
                        addressBook.SortByName();
                        break;
                    case 12:                       
                        Console.WriteLine("Thank You For Using Address Book System.");
                        break;
                }
            } while (choice != 12);
        }
    }
}
