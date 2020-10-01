﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookDetails
    {
        string nameOfAddressBook;
        const string ADD_CONTACT = "add";
        const string UPDATE_CONTACT = "update";
        const string SEARCH_CONTACT = "search";
        const string REMOVE_CONTACT = "remove";
        const string GET_ALL_CONTACTS = "view";
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
            if (addressBookList.Count == 0)
                Console.WriteLine("No record found");
            else
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
            
               
        }

        internal void ViewAllAddressBooks()
        {
            if (addressBookList.Count == 0)
                Console.WriteLine("No record found");
            else
            {
                Console.WriteLine("\nThe namesof address books available are :");
                foreach (KeyValuePair<string, AddressBook> keyValuePair in addressBookList)
                    Console.WriteLine(keyValuePair.Key);
            }
            
        }

        public void AddOrAccessAddressBook()
        {
            AddressBook addressBook = GetAddressBook();
            bool flag = true;
            while (flag)
            {
                if (addressBook != null)
                {
                    Console.WriteLine("\nSelect from below to work on Address book {0}", addressBook.nameOfAddressBook);
                    Console.WriteLine("\nType\n\nAdd - To add a contact \nUpdate- To update a contact\nView - To view all contacts\nRemove - To remove a contact and \nSearch- To search to get contact deatails\nE - To exit\n ");

                    switch (Console.ReadLine().ToLower())
                    {
                        case ADD_CONTACT:

                            addressBook.AddContact();
                            break;

                        case UPDATE_CONTACT:

                            addressBook.UpdateContact();
                            break;

                        case SEARCH_CONTACT:

                            addressBook.DisplayContactDetails();
                            break;
                        case REMOVE_CONTACT:
                            addressBook.RemoveContact();
                            break;
                        case GET_ALL_CONTACTS:
                            addressBook.GetAllContacts();
                            break;

                        default:
                            flag = false;
                            Console.WriteLine("\nInvalid option. Try again");
                            continue;
                    }
                        Console.WriteLine("\nType y to continue in same address Book or any other key to exit");
                        if (!(Console.ReadLine().ToLower() == "y"))
                        flag = false;

                }
                else
                    Console.WriteLine("\nAddress Book not found");

            }
        }

        
    }
}
