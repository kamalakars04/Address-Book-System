using System;
using System.Collections.Generic;

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
        const string TO_ADD_OR_ACCESS = "add";
        const string TO_VIEW_ALL_ADDRESSBOOKS = "view";
        const string TO_DELETE_ADDRESS_BOOK = "delete";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Program");

            AddressBookDetails addressBookDetails = new AddressBookDetails();

            bool flag = true;
            while(flag)
            {
                Console.WriteLine("\nType to select address book\nAdd - To add or access address book\nview - To view all names of address books\nDelete - To delete Address book\nE - To exit");

                switch (Console.ReadLine().ToLower())
                {
                    case TO_ADD_OR_ACCESS:
                        addressBookDetails.AddOrAccessAddressBook();
                        break;

                    case TO_VIEW_ALL_ADDRESSBOOKS:
                        addressBookDetails.ViewAllAddressBooks();
                        break;

                    case TO_DELETE_ADDRESS_BOOK:
                        addressBookDetails.DeleteAddressBook();
                        break;

                    default:
                        flag = false;
                        break;

                }
            }
            

        }
    }
}
