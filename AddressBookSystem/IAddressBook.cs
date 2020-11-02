using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    /// <summary>
    /// Address book interface to implement behaviour of class. 
    /// </summary>
    interface IAddressBook
    {
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
        /// <param name="email">The email address.</param>
        public void AddContact(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string email);
        /// <summary>
        /// Displays the contact.
        /// </summary>
        public void DisplayContact(string name);
        /// <summary>
        /// Edits the contact.
        /// </summary>
        /// <param name="name">The name.</param>
        public void EditContact(string name);
        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="name">The name.</param>
        public void DeleteContact(string name);
    }
}
