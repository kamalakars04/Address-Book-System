﻿using System;

namespace AddressBookSystem
{
    /// <summary>
    /// Interface creted for abstraction and easy access for user
    /// </summary>
    public interface IAddressBook
    {
        void DisplayContactDetails();
        void AddContact();
        public void UpdateContact();
        void RemoveContact();



    }
    class Program
    {
        const string addContact = "add";
        const string updateContact = "update";
        const string searchContact = "search";
        const string removeContact = "remove";
        
        static void Main(string[] args)
        {
            bool flag=true;
            
            Console.WriteLine("Welcome to Address Book Program");

            AddressBook addressBook = new AddressBook();
            while(flag)
            {

                Console.WriteLine("\nType\nAdd - To add a contact \nupdate- To update a contact\nremove - To remove a contact and \nsearch- To search to get contact deatails");

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
                        Console.WriteLine("Invalid option. Try again");
                        Console.WriteLine("Enter any key to exit");
                        break;
                }

            }

            Console.ReadKey();
        }
    }
}
