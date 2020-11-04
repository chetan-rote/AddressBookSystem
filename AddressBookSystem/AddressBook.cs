﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AddressBookSystem
{
    public class AddressBook : IAddressBook
    {
        /// The address book stores contact details     
        private Dictionary<string, Contact> addressBook = new Dictionary<string, Contact>();
        /// The address book dictionary stores address books.
        private Dictionary<string, AddressBook> addressBookDictionary = new Dictionary<string, AddressBook>();
        /// The dictionary to store city.
        private Dictionary<Contact, string> cityDictionary = new Dictionary<Contact, string>();
        /// The dictionary to store state.
        private Dictionary<Contact, string> stateDictionary = new Dictionary<Contact, string>();
        /// <summary>
        /// UC_1
        /// Adds the contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="email">The email address.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="bookName"></param>
        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNumber, string bookName)
        {
            Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email, bookName);
            addressBookDictionary[bookName].addressBook.Add(contact.FirstName, contact);
            Console.WriteLine("\nAdded Succesfully. \n");

            if (CheckForSpace(firstName, lastName))
            {
                Console.WriteLine("Enter Valid Name");
            }
            else
            {
                CheckDuplicateEntry(contact, bookName);
            }
        }
        /// <summary>
        /// Displays the contact.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="bookName"></param>
        public void ViewContact(string name, string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
            {
                if (item.Key.Equals(name))
                {
                    Console.WriteLine("First Name   : " + item.Value.FirstName);
                    Console.WriteLine("Last Name    : " + item.Value.LastName);
                    Console.WriteLine("Address      : " + item.Value.Address);
                    Console.WriteLine("City         : " + item.Value.City);
                    Console.WriteLine("State        : " + item.Value.State);
                    Console.WriteLine("Email        : " + item.Value.Email);
                    Console.WriteLine("Zip          : " + item.Value.Zip);
                    Console.WriteLine("Phone Number : " + item.Value.PhoneNumber + "\n");
                }
            }
        }
        /// <summary>
        /// Views all contacts.
        /// </summary>
        /// <param name="bookName">Name of the book.</param>
        public void ViewAllContacts(string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
            {
                Console.WriteLine("First Name   : " + item.Value.FirstName);
                Console.WriteLine("Last Name    : " + item.Value.LastName);
                Console.WriteLine("Address      : " + item.Value.Address);
                Console.WriteLine("City         : " + item.Value.City);
                Console.WriteLine("State        : " + item.Value.State);
                Console.WriteLine("Email        : " + item.Value.Email);
                Console.WriteLine("Zip          : " + item.Value.Zip);
                Console.WriteLine("Phone Number : " + item.Value.PhoneNumber + "\n");
            }
        }
        /// <summary>
        /// UC_3
        /// Edits the contact.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="bookName"></param>
        public void EditContact(string name, string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
            {
                if (item.Key.Equals(name))
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
                    Console.WriteLine("\nEdited Successfully.\n");
                }
            }
        }
        /// <summary>
        /// UC_4
        /// Deletes the contact.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="bookName"></param>
        public void DeleteContact(string name, string bookName)
        {
            if (addressBookDictionary[bookName].addressBook.ContainsKey(name))
            {
                addressBookDictionary[bookName].addressBook.Remove(name);
                Console.WriteLine("\nDeleted Succesfully.\n");
            }
            else
            {
                Console.WriteLine("\nNot Found, Try Again.\n");
            }
        }
        /// <summary>
        /// UC_6
        /// Adds the address book.
        /// </summary>
        /// <param name="bookName">Name of the book.</param>
        public void AddAddressBook(string bookName)
        {
            AddressBook addressBook = new AddressBook();
            addressBookDictionary.Add(bookName, addressBook);
            Console.WriteLine("AddressBook Created.");
        }
        /// <summary>
        /// Gets the address book.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, AddressBook> GetAddressBook()
        {
            return addressBookDictionary;
        }
        /// <summary>
        /// Checks the duplicate entry in Address Book.
        /// </summary>
        /// <param name="contacts">The c.</param>
        /// <param name="bookName">Name of the book.</param>
        /// <returns></returns>
        public bool CheckDuplicateEntry(Contact contacts, string bookName)
        {
            List<Contact> book = GetListOfDictctionaryKeys(bookName);
            if (book.Any(b => b.Equals(contacts)))
            {
                Console.WriteLine("Name already Exists.");
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks for blank space.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastname">The lastname.</param>
        /// <returns></returns>
        public bool CheckForSpace(string firstName, string lastname)
        {
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastname))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Gets the list of dictctionary keys.
        /// </summary>
        /// <param name="bookName">Name of the book.</param>
        /// <returns></returns>
        public List<Contact> GetListOfDictctionaryKeys(string bookName)
        {
            List<Contact> book = new List<Contact>();
            foreach (var value in addressBookDictionary[bookName].addressBook.Values)
            {
                book.Add(value);
            }
            return book;
        }
        /// <summary>
        /// Gets the list of dictctionary keys2.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns></returns>
        public List<Contact> GetListOfDictctionaryKeys2(Dictionary<string, Contact> d)
        {
            List<Contact> book = new List<Contact>();
            foreach (var value in d.Values)
            {
                book.Add(value);
            }
            return book;
        }
        /// <summary>
        /// UC_8
        /// Finds contacts by city.
        /// </summary>
        /// <param name="city">The city.</param>
        public void SearchPersonByCity(string city)
        {
            foreach (AddressBook addressbookobj in addressBookDictionary.Values)
            {
                List<Contact> contactList = GetListOfDictctionaryKeys2(addressbookobj.addressBook);
                foreach (Contact contact in contactList.FindAll(c => c.City.Equals(city)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        /// <summary>
        /// Searches the contacts by state.
        /// </summary>
        /// <param name="state">The state.</param>
        public void SearchPersonByState(string state)
        {
            foreach (AddressBook addressbookobj in addressBookDictionary.Values)
            {
                List<Contact> contactList = GetListOfDictctionaryKeys2(addressbookobj.addressBook);
                foreach (Contact contact in contactList.FindAll(c => c.State.Equals(state)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        /// <summary>
        /// Views the contacts by city.
        /// </summary>
        public void ViewByCity(string city)
        {
            foreach (AddressBook addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookObj.addressBook.Values)
                {
                    addressBookObj.cityDictionary.Add(contact, contact.City);
                }
            }
        }
        /// <summary>
        /// Views the contacts by state.
        /// </summary>
        public void ViewByState(string state)
        {
            foreach (AddressBook addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookObj.addressBook.Values)
                {
                    addressBookObj.stateDictionary.Add(contact, contact.State);
                }
            }
        }
    }
}
