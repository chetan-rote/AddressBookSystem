using System;
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
        /// UC_8
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
        /// UC_9
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
        /// UC_9
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
        /// <summary>
        /// Adds contacts data to city dictionary.
        /// </summary>
        public void CreateCityDictionary()
        {
            foreach (AddressBook addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookObj.addressBook.Values)
                {
                    addressBookObj.cityDictionary.TryAdd(contact, contact.City);
                }
            }
        }
        /// <summary>
        /// Adds data to State Dictionary
        /// </summary>
        public void CreateStateDictionary()
        {
            foreach (AddressBook addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookObj.addressBook.Values)
                {
                    addressBookObj.stateDictionary.TryAdd(contact, contact.State);
                }
            }
        }
        /// <summary>
        /// UC_10
        /// Gives counts of person by city and state.
        /// </summary>
        public void CountPersonByCityOrState()
        {
            CreateCityDictionary();
            CreateStateDictionary();
            Dictionary<string, int> countByCity = new Dictionary<string, int>();
            Dictionary<string, int> countByState = new Dictionary<string, int>();
            foreach (var obj in addressBookDictionary.Values)
            {
                foreach (var person in obj.cityDictionary)
                {
                    countByCity.TryAdd(person.Value, 0);
                    countByCity[person.Value]++;
                }
            }
            Console.WriteLine("City wise count :");
            foreach (var person in countByCity)
            {
                Console.WriteLine(person.Key + ":" + person.Value);
            }
            foreach (var obj in addressBookDictionary.Values)
            {
                foreach (var person in obj.stateDictionary)
                {
                    countByState.TryAdd(person.Value, 0);
                    countByState[person.Value]++;
                }
            }
            Console.WriteLine("State wise count :");
            foreach (var person in countByState)
            {
                Console.WriteLine(person.Key + ":" + person.Value);
            }
        }
        /// <summary>
        /// Sorts the Contacts in address book by alphabetical order.
        /// </summary>
        public void SortByName()
        {
            foreach (AddressBook addressBookobj in addressBookDictionary.Values)
            {
                List<string> list = addressBookobj.addressBook.Keys.ToList();
                list.Sort();
                foreach (string name in list)
                {
                    Console.WriteLine(addressBookobj.addressBook[name].ToString());
                }
            }
        }
        /// <summary>
        /// Sorts the contacts by city.
        /// </summary>
        public void SortByCity()
        {
            CreateCityDictionary();
            Dictionary<string, Contact> inverseCityDictionary = new Dictionary<string, Contact>();
            foreach (AddressBook obj in addressBookDictionary.Values)
            {
                foreach (Contact contact in obj.cityDictionary.Keys)
                {
                    inverseCityDictionary.TryAdd(contact.City, contact);
                }
            }
            List<string> list = inverseCityDictionary.Keys.ToList();
            list.Sort();
            foreach (string city in list)
            {
                Console.WriteLine(inverseCityDictionary[city].ToString());
            }
        }
        /// <summary>
        /// Sorts the contacts by states.
        /// </summary>
        public void SortByState()
        {
            CreateStateDictionary();
            Dictionary<string, Contact> inverseStateDictionary = new Dictionary<string, Contact>();
            foreach (AddressBook obj in addressBookDictionary.Values)
            {
                foreach (Contact contact in obj.stateDictionary.Keys)
                {
                    inverseStateDictionary.TryAdd(contact.State, contact);
                }
            }
            List<string> list = inverseStateDictionary.Keys.ToList();
            list.Sort();
            foreach (string state in list)
            {
                Console.WriteLine(inverseStateDictionary[state].ToString());
            }
        }
        /// <summary>
        /// Sorts the contacts by zip.
        /// </summary>
        public void SortByZip()
        {
            SortedList<int, Contact> sortedbyCity = new SortedList<int, Contact>();
            foreach (AddressBook addressBookobj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookobj.addressBook.Values)
                {
                    sortedbyCity.TryAdd(contact.Zip, contact);
                }
            }
            foreach (var item in sortedbyCity)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
