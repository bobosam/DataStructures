using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Phonebook
{
    class Phonebook
    {
        static void Main()
        {
            var phoneBook = new HashTable<string, string>();
            string inputContactInfo = Console.ReadLine();

            while (!inputContactInfo.Equals("search"))
            {
                string[] nameAndPhone = inputContactInfo.Split('-');
                string name = nameAndPhone[0];
                string phoneNumber = nameAndPhone[1];

                if (!phoneBook.ContainsKey(name))
                {
                    phoneBook[name] = phoneNumber;
                }
                else
                {
                    Console.WriteLine("* The name \"{0}\" already exists in contact list.", name);
                }
                inputContactInfo = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine("-- Please, input \"end\" to see the search results --\n");
            string inputName = Console.ReadLine();
            var names = new List<string>();

            while (!inputName.Equals("end"))
            {
                names.Add(inputName);
                inputName = Console.ReadLine();
            }

            Console.WriteLine();
            foreach (var name in names)
            {
                if (phoneBook.ContainsKey(name))
                {
                    Console.WriteLine("{0} -> {1}", name, phoneBook[name]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", name);
                }
            }
        }
    }
}
