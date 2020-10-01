using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookDetails
    {
        string nameOfAddressBook;
        const string addContact = "add";
        const string updateContact = "update";
        const string searchContact = "search";
        const string removeContact = "remove";
        public Dictionary<string, AddressBook> addressBookList = new Dictionary<string, AddressBook>();


       

        private AddressBook GetAddressBook()
        {
            Console.WriteLine("\nEnter name of Address Book to be accessed or to be added");
            nameOfAddressBook = Console.ReadLine();

            //search for address book in dictionary
            if (addressBookList.ContainsKey(nameOfAddressBook))
            {
                Console.WriteLine("\nAddressBook Identified");
                return addressBookList[nameOfAddressBook];
            } 

            //Offer to create a address book if not found in dictionary
            else
            {
                Console.WriteLine("\nAddress book not found. Type y to create a new address book or E to abort");
                if ((Console.ReadLine().ToLower()) == "y")
                {
                    AddressBook addressBook = new AddressBook(nameOfAddressBook);
                    addressBookList.Add(nameOfAddressBook, addressBook);
                    Console.WriteLine("\nNew AddressBook Created");
                    return addressBookList[nameOfAddressBook];
                }
                else
                    Console.WriteLine("\nAction Aborted");
                return null;

            }
        }

        internal void DeleteAddressBook()
        {
            Console.WriteLine("\nEnter the name of address book to be deleted :");

            //search for address book with given name
            try
            {
                addressBookList.Remove(Console.ReadLine());
                Console.WriteLine("Address book deleted successfully");
            }
            catch
            {
                Console.WriteLine("Address book not found");
            }
               
        }

        internal void ViewAllAddressBooks()
        {
            Console.WriteLine("\nThe namesof address books available are :");
            foreach (KeyValuePair<string,AddressBook> keyValuePair in addressBookList)
                Console.WriteLine(keyValuePair.Key);
        }

        public void AddOrAccessAddressBook()
        {
            bool flag = true;
            while (flag)
            {
                AddressBook addressBook = GetAddressBook();
                if (addressBook != null)
                {
                    Console.WriteLine("\nSelect from below to work on Address book {0}", addressBook.nameOfAddressBook);
                    Console.WriteLine("\nType\n\nAdd - To add a contact \nUpdate- To update a contact\nRemove - To remove a contact and \nSearch- To search to get contact deatails\n");

                    switch (Console.ReadLine().ToLower())
                    {
                        case addContact:

                            addressBook.AddContact();
                            break;

                        case updateContact:

                            addressBook.UpdateContact();
                            break;

                        case searchContact:

                            addressBook.DisplayContactDetails();
                            break;
                        case removeContact:
                            addressBook.RemoveContact();
                            break;

                        default:
                            flag = false;
                            Console.WriteLine("\nInvalid option. Try again");
                            Console.WriteLine("\nEnter any key to exit");
                            break;
                    }
                }
                else
                    Console.WriteLine("\nAddress Book not found");

            }
        }

        
    }
}
