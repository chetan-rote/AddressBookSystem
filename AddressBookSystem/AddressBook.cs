using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBook : IAddressBook
    {
        /// <summary>
        /// The address book dictionary.
        /// </summary>
        private Dictionary<string, Contact> addressBook = new Dictionary<string, Contact>();
        /// <summary>
        /// Adds the contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="emailAddress">The email address.</param>
        public void AddContact(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string email)
        {
            Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            addressBook.Add(contact.FirstName, contact);
            Console.WriteLine("\nAdded Succesfully. \n");
        }
        /// <summary>
        /// Displays the contact.
        /// </summary>
        public void DisplayAllContact()
        {
            foreach (KeyValuePair<string, Contact> pair in addressBook)
            {
                Console.WriteLine("First Name : " + pair.Value.FirstName);
                Console.WriteLine("Last Name : " + pair.Value.LastName);
                Console.WriteLine("Address : " + pair.Value.Address);
                Console.WriteLine("City : " + pair.Value.City);
                Console.WriteLine("State : " + pair.Value.State);
                Console.WriteLine("Zip : " + pair.Value.Zip);
                Console.WriteLine("Phone Number : " + pair.Value.PhoneNumber);
                Console.WriteLine("Email : " + pair.Value.Email + "\n");
            }
        }
        /// <summary>
        /// Edits the contact.
        /// </summary>
        /// <param name="name">The name.</param>
        public void EditContact(string firstName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBook)
            {
                if (item.Key.Equals(firstName))
                {
                    Console.WriteLine("Choose What to Edit \n1.First Name \n2.Last Name \n3.Address \n4.City \n5.State \n6.Email \n7.Zip \n8.Phone Number");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter New First Name :");
                            item.Value.FirstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter New Last Name :");
                            item.Value.LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter New Address :");
                            item.Value.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter New City :");
                            item.Value.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter New State :");
                            item.Value.State = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter New Email :");
                            item.Value.Email = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter New Zip :");
                            item.Value.Zip = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Enter New Phone Number :");
                            item.Value.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Delete's the contact using name.
        /// </summary>
        /// <param name="name"></param>
        public void DeleteContact(string name)
        {
            if (addressBook.ContainsKey(name))
            {
                addressBook.Remove(name);
                Console.WriteLine("\nDeleted Succesfully.\n");
            }
            else
            {
                Console.WriteLine("\nNot Found, Try Again.\n");
            }
        }
    }
}
