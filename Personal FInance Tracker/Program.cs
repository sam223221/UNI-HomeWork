using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

namespace PersonalFinanceTracker
{
    class CreateAccount
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Balance { get; private set; }
        public int Id { get; private set; }

        public CreateAccount(string firstName, string lastName, int deposit)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = deposit;
            Id = IdGenerator();
            Console.WriteLine($"Your ID is {Id}");
        }

        public void AccountInfo()
        {
            Console.WriteLine($"Your first name is {FirstName}");
            Console.WriteLine($"Your last name is {LastName}");
            Console.WriteLine($"Your deposit is {Balance}");
        }

        private static int IdGenerator()
        {
            Random rand = new Random();
            int randomNumber = 0;

            for (int i = 0; i < 8; i++)
            {
                int digit = i == 0 ? rand.Next(1, 10) : rand.Next(0, 10);
                randomNumber = randomNumber * 10 + digit;
            }

            return randomNumber;
        }
    }

    class AccountDB
    {
        public List<CreateAccount> accounts = new List<CreateAccount>();

        public void AddAccount(CreateAccount account)
        {
            accounts.Add(account);
        }
        
    }

    class Program
    {
        AccountDB accountDB = new();
        private const string Filepath = "transaction.json";

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to the Personal Finance Tracker.");
            Console.WriteLine("In this program, you can track your income and expenses.");

            CreateAccount account = new("John", "Doe", 20);
            CreateAccount account1 = new("Madmand", "dove", 696969);
            account.AccountInfo();

        }

        

        static void accountCreator()
        {
            Console.WriteLine("What is your first name?");
            Console.Write(" > ");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is your last name?");
            Console.Write(" > ");
            string lastName = Console.ReadLine();

            Console.WriteLine("What is your initial deposit?");
            Console.Write(" > ");
            int deposit = int.Parse(Console.ReadLine());

            CreateAccount account = new(firstName, lastName, deposit);
            SaveAccount(account); // Save the newly created account to the JSON file

        }


        static void SaveAccount(CreateAccount account)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(account);
                File.WriteAllText(Filepath, jsonString);
                Console.WriteLine("Account saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }




        static void LoadAccount()
        {
            try
            {
                string jsonString = File.ReadAllText(Filepath);
                CreateAccount account = JsonSerializer.Deserialize<CreateAccount>(jsonString);
                Console.WriteLine($"Your first name is {account.FirstName}");
                Console.WriteLine($"Your last name is {account.LastName}");
                Console.WriteLine($"Your deposit is {account.Balance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
