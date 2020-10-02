using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
namespace AddressBookSystem
{
    class AddressBook : IAddressBook
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public List<ContactDetails> contactList = new List<ContactDetails>();
        const int UPDATE_FIRST_NAME = 1;
        const int UPDATE_LAST_NAME = 2;
        const int UPDATE_ADDRESS = 3;
        const int UPDATE_CITY = 4;
        const int UPDATE_STATE = 5;
        const int UPDATE_ZIP = 6;
        const int UPDATE_PHONE_NUMBER = 7;
        const int UPDATE_EMAIL = 8;
        int IF_INVALID_ENTRY = 0;
        int contactSerialNum = 0;
        public string nameOfAddressBook = " ";
        // string name = " ";
        public AddressBook(string name)
        {
             nameOfAddressBook = name;
        }
        public void AddContact()
        {
            string firstName;
            string lastName;
            string address;
            string city;
            string state;
            string zip;
            string phoneNumber;
            string email;

            Console.WriteLine("\nEnter The First Name of Contact");
            firstName = Console.ReadLine();

            Console.WriteLine("\nEnter The Last Name of Contact");
            lastName = Console.ReadLine();

            Console.WriteLine("\nEnter The Address of Contact");
            address = Console.ReadLine();

            Console.WriteLine("\nEnter The City Name of Contact");
            city = Console.ReadLine();

            Console.WriteLine("\nEnter The State Name of Contact");
            state = Console.ReadLine();

            Console.WriteLine("\nEnter the Zip of Locality of Contact");
            zip = Console.ReadLine();

            Console.WriteLine("\nEnter The Phone Number of Contact");
            phoneNumber = Console.ReadLine();

            Console.WriteLine("\nEnter The Email of Contact");
            email = Console.ReadLine();

            // Adding contact into address book
            ContactDetails addNewContact = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, email);

            //Checking for duplicates
            try
            {
               
                foreach (ContactDetails contact in contactList)
                {
                    if ((contact.firstName + " " + contact.lastName).Equals(firstName + " " + lastName))
                    {
                        logger.Error("User tried to create a duplicate of contact");
                        Console.WriteLine("\nThe name of the contact already exits.Press Y to save a copy as {0}1 or any other key to exit", (contact.firstName + " " + contact.lastName));
                        throw new Exception();
                    }
                }
                contactList.Add(addNewContact);
                Console.WriteLine("\nContact Added");
                logger.Info("User created a new contact");
               
            }

            // Eliminating the exception of duplicate
            catch
            {
                if ((Console.ReadLine().ToLower() == "y"))
                {
                    addNewContact.lastName += "1"; 
                    contactList.Add(addNewContact);
                    Console.WriteLine("\nContact Added");
                    logger.Info("User created a new contact");

                }

            }
        }

        public void DisplayContactDetails()
        {
            if (contactList.Count() == 0)
                Console.WriteLine("No saved contacts");
            else
            {
                Console.WriteLine("\nEnter the name of candidate to get Details");
                string name = Console.ReadLine().ToLower();
                logger.Info("User searched for a contact "+ name);
                contactSerialNum = SearchByName(name);
                toString(contactSerialNum);
            }

        }

       
      
        public void UpdateContact()
        {
            if (contactList.Count() == 0)
                Console.WriteLine("No saved contacts");
            else
            {
                // Input the name to be updated
                Console.WriteLine("\nEnter the name of candidate to be updated");
                string name = Console.ReadLine().ToLower();
                logger.Info("User tried to update contact" + name);
                //search the name
                int contactSerialNum = SearchByName(name);

                //If name not found
                if (contactSerialNum < 0)
                    Console.WriteLine("Contact Not Saved");

                //If name found
                else
                {
                    //To print details of searched contact
                    toString(contactSerialNum);
                    int updateAttributeNum = 0;

                    //Getting the attribute to be updated
                    Console.WriteLine("\nEnter the row number attribute to be updated");

                    updateAttributeNum = Convert.ToInt32(Console.ReadLine());

                    //Getting the new value of attribute
                    Console.WriteLine("\nEnter the new value to be entered");
                    string newValue = Console.ReadLine();

                    //Updating selected attribute with selected value
                    switch (updateAttributeNum)
                    {
                        case UPDATE_FIRST_NAME:
                            contactList[contactSerialNum].firstName = newValue;
                            break;
                        case UPDATE_LAST_NAME:
                            contactList[contactSerialNum].lastName = newValue;
                            break;
                        case UPDATE_ADDRESS:
                            contactList[contactSerialNum].address = newValue;
                            break;
                        case UPDATE_CITY:
                            contactList[contactSerialNum].city = newValue;
                            break;
                        case UPDATE_STATE:
                            contactList[contactSerialNum].state = newValue;
                            break;
                        case UPDATE_ZIP:
                            contactList[contactSerialNum].zip = newValue;
                            break;
                        case UPDATE_PHONE_NUMBER:
                            contactList[contactSerialNum].phoneNumber = newValue;
                            break;
                        case UPDATE_EMAIL:
                            contactList[contactSerialNum].email = newValue;
                            break;
                        default:
                            Console.WriteLine("Invalid Entry");
                            IF_INVALID_ENTRY = 1;
                            break;
                    }
                    if (IF_INVALID_ENTRY == 0)
                    {
                        logger.Info("User updated contact");
                        Console.WriteLine("\nUpdate Successful");
                    }

                }
            }
 
        }

        
        public void RemoveContact()
        {
            if (contactList.Count() == 0)
                Console.WriteLine("No saved contacts");

            else
            {
                //Input the name of the contact to be removed
                Console.WriteLine("\nEnter the name of contact to be removed");
                string name = Console.ReadLine().ToLower();

                logger.Info("User requested to remove contact " + name);
                //Search for the contact
                int contactSerialNum = SearchByName(name);

                //Print the details of contact for confirmation
                toString(contactSerialNum);

                //If contact known then delete
                if (contactSerialNum >= 0)
                {
                    Console.WriteLine("Press y to confirm delete or any other key to abort");
                    switch (Console.ReadLine().ToLower())
                    {
                        case "y":
                            contactList.RemoveAt(contactSerialNum);
                            Console.WriteLine("Contact deleted");
                            logger.Info("User removed the contact");
                            break;
                        default:
                            Console.WriteLine("Deletion aborted");
                            logger.Info("User aborted the process");
                            break;
                    }
                }
            }
        }

        public void GetAllContacts()
        {
            if (contactList.Count() == 0)
                Console.WriteLine("\nNo saved contacts");
            else
            {
                logger.Info("User viewd all contacts");
                foreach (ContactDetails contact in contactList)
                    toString(contactList.IndexOf(contact));
            }

        }

        private int SearchByName(string name)
        {
            int numOfConatctsWithNameSearched = 0;
            
            if (contactList.Count == 0)
                return -1;
            
            else
            {
                // Loop to find exact name being searched
                while (numOfConatctsWithNameSearched == 0)
                {
                    int numOfContactsSearched = 0;

                    //Search if Contacts have the given string in name
                    foreach (ContactDetails contact in contactList)
                    {
                        numOfContactsSearched++;

                        // If contact name matches exactly then it returns the index of that contact
                        if ((contact.firstName + " " + contact.lastName).Equals(name))
                            return contactList.IndexOf(contact);

                        //If a part of contact name matches then we would ask them to enter accurately
                        else if ((contact.firstName + " " + contact.lastName).Contains(name))
                        {
                            logger.Error("Multiple contacts exists with given name");
                            numOfConatctsWithNameSearched++; // num of contacts having search string
                            Console.WriteLine("\nname of contact is {0}", contact.firstName + " " + contact.lastName);
                        }

                        //If string is not part of any name then exit
                        else
                            return -1;

                        if (numOfContactsSearched == contactList.Count() && numOfConatctsWithNameSearched > 0)
                        {
                            Console.WriteLine("\nInput the contact name as firstName lastName\n or E to exit");
                            name = Console.ReadLine().ToLower();
                            if (name.ToLower() == "e")
                                return -1;
                            numOfConatctsWithNameSearched = 0;
                        }
                    }
                }

            }
            return 0;
        }

        private void toString(int contactSerialNum)
        {
            if (contactSerialNum < 0)
            {
                Console.WriteLine("Contact Not found");
                logger.Error("Contact not found");
            }
            else
            {
                int rowNum = 1;
                Console.WriteLine("\nname of contact is {0}", contactList[contactSerialNum].firstName + " " + contactList[contactSerialNum].lastName);
                Console.WriteLine("{0}-firstname is {1}", rowNum++, contactList[contactSerialNum].firstName);
                Console.WriteLine("{0}-lastname is {1}", rowNum++, contactList[contactSerialNum].lastName);
                Console.WriteLine("{0}-address is {1}", rowNum++, contactList[contactSerialNum].address);
                Console.WriteLine("{0}-city is {1}", rowNum++, contactList[contactSerialNum].city);
                Console.WriteLine("{0}-state is {1}", rowNum++, contactList[contactSerialNum].state);
                Console.WriteLine("{0}-zip is {1}", rowNum++, contactList[contactSerialNum].zip);
                Console.WriteLine("{0}-phoneNumber is {1}", rowNum++, contactList[contactSerialNum].phoneNumber);
                Console.WriteLine("{0}-email is {1}", rowNum++, contactList[contactSerialNum].email);
            }
           
        }
    }
}
