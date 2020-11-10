using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AddressBookSystem
{
    public class AddressBookFileIO
    {
        //private static filePath = @"C:\Users\Chetan\source\repos\AddressBookSystem\AddressBookSystem\Utility\AddressBook.txt";
        /// <summary>
        /// Writes the to AddressBook.txt using stream writer.
        /// </summary>
        /// <param name="data">The data.</param>
        public static void WriteUsingStreamWriter(Dictionary<string, AddressBook> addressBookDictionary)
        {
            string path = @"C:\Users\Chetan\source\repos\AddressBookSystem\AddressBookSystem\Utility\AddressBook.txt";
            if (File.Exists(path))
            {
                using StreamWriter writer = new StreamWriter(path, true);
                foreach (AddressBook addressBookobj in addressBookDictionary.Values)
                {
                    foreach (Contact contact in addressBookobj.addressBook.Values)
                    {
                        writer.WriteLine(contact.ToString());
                    }
                }
                Console.WriteLine("\nSuccessfully added to Text file.");
                writer.Close();
            }
            else
            {
                Console.WriteLine("File does'nt exists");
            }
        }

        /// <summary>
        /// Reads the data from AddressBook.txt using stream reader.
        /// </summary>
        public static void ReadUsingStreamReader()
        {
            string path = @"C:\Users\Chetan\source\repos\AddressBookSystem\AddressBookSystem\Utility\AddressBook.txt";
            if (File.Exists(path))
            {
                Console.WriteLine("Below are Contents of Text File");
                string lines = File.ReadAllText(path);
                Console.WriteLine(lines);
            }
            else
            {
                Console.WriteLine("File does'nt exists");
            }
        }
    }
}
