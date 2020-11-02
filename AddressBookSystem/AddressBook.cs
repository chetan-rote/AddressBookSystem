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
        public void AddContact(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string emailAddress)
        {
            Contact contact = new Contact();
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.Address = address;
            contact.City = city;
            contact.State = state;
            contact.Zip = zip;
            contact.Email = emailAddress;
            contact.PhoneNumber = phoneNumber;
            addressBook.Add(contact.FirstName, contact);
        }
        /// <summary>
        /// Displays the contact.
        /// </summary>
        public void DisplayContact()
        {
            foreach (KeyValuePair<string, Contact> pair in addressBook)
            {
                Console.WriteLine("First Name : " + pair.Value.FirstName);
                Console.WriteLine("Address : " + pair.Value.Address);
                Console.WriteLine("City : " + pair.Value.City);
                Console.WriteLine("State : " + pair.Value.State);
                Console.WriteLine("Zip : " + pair.Value.Zip);
                Console.WriteLine("Phone Number : " + pair.Value.PhoneNumber);
                Console.WriteLine("Email : " + pair.Value.Email + "\n");
            }
        }
    }
}
