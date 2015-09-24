using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTable;

namespace Problem03Phonebook
{
    class Problem03Phonebook
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter end to stop program.");
            Console.WriteLine("Please enter search to star search phonenumbers.");
            var phonebook = new HashTable<string, string>();
            string inputText;
            while (true)
            {
                inputText = Console.ReadLine();
                
                if (inputText.Equals("end"))
                {
                    return;
                }

                if (inputText.Equals("search"))
                {
                    SearchNumbers(phonebook);
                    return;
                }

                string[] splitText = inputText.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string inputName = splitText[0].Trim();

                if (splitText.Count() > 1)
                {
                    string phonenumber = splitText[1].Trim();

                    if (!phonebook.ContainsKey(inputName))
                    {
                        phonebook.Add(inputName, phonenumber);
                    }
                    else
                    {
                        phonebook[inputName] = phonenumber;
                    }
                }
            }
        }

        public static void SearchNumbers(HashTable<string, string> phonebook)
        {
            string inputName;
            while (true)
            {
                inputName = Console.ReadLine();
                if (inputName.Equals("end"))
                {
                    return;
                }
                if (phonebook.ContainsKey(inputName))
                {
                    string phonenumber;
                    phonebook.TryGetValue(inputName, out phonenumber);
                    Console.WriteLine("{0} -> {1}", inputName, phonenumber);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", inputName);
                }
            }
        }
    }
}
