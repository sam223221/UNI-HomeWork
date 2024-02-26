using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PersonalFinanceTracker
{
        public class CreateAccount
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Password { get; internal set; }
        public int Balance { get; internal set; }
        public int Id { get; internal set; }


        [JsonConstructor]
        public CreateAccount(string firstName, string lastName, int balance,string password, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            Password = password;
            Id = id;
        }

        // Constructor with parameters for manual object creation
        public CreateAccount(string firstName, string lastName,string password, int deposit)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Balance = deposit;
            Id = IdGenerator();
            Console.WriteLine($"Your ID is {Id}");
        }

        public void AccountInfo()
        {
            Console.WriteLine($"Your first name is      : {FirstName}");
            Console.WriteLine($"Your last name is       : {LastName}");
            Console.WriteLine($"Your current balance is : {Balance}");
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
        private const string Filepath = "transaction.json";
        public List<CreateAccount> Accounts { get; } = new List<CreateAccount>();

        public void AddAccount(CreateAccount account)
        {
            Accounts.Add(account);
            SaveAccount(account);
        }

        // Saves the account by serializing the 'CreateAccount' object to a JSON string, 
        // writing it to the specified file, and then printing a success message. 
        public void SaveAccount(CreateAccount account)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(Accounts);
                File.WriteAllText(Filepath, jsonString);
                Console.WriteLine("Account saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // A method to load accounts from a file and deserialize them into a list of CreateAccount objects.
        public void LoadAccounts()
        {
            try
            {
                string jsonString = File.ReadAllText(Filepath);
                List<CreateAccount> loadedAccounts = JsonSerializer.Deserialize<List<CreateAccount>>(jsonString);

                if (loadedAccounts != null)
                {
                    Accounts.Clear(); // Clear the existing list
                    Accounts.AddRange(loadedAccounts); // Add the loaded accounts
                    foreach (var item in Accounts)
                    {
                        Console.WriteLine(item.FirstName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"there where no accounts saved");
            }
        }
    }

    class AccountManager
    {
        private AccountDB AccountDb { get; }

        // Constructor for creating an instance of AccountManager with the provided AccountDB object.
        public AccountManager(AccountDB accountDb)
        {
            AccountDb = accountDb;
        }

        // A simple function that creates an account by prompting the user for their first name, last name, password, and initial deposit. It then creates an account object and adds it to the account database.
        public void AccountCreator()
        {
            Console.WriteLine("What is your first name?");
            Console.Write(" > ");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is your last name?");
            Console.Write(" > ");
            string lastName = Console.ReadLine();

            Console.WriteLine("What is your password?");
            Console.Write(" > ");
            string password = Console.ReadLine();

            Console.WriteLine("What is your initial deposit?");
            Console.Write(" > ");
            int deposit = 0;
            while (!int.TryParse(Console.ReadLine(), out deposit))
            {
                Console.WriteLine("Invalid input, please enter a number.");
                Console.Write(" > ");
            }

            CreateAccount account = new(firstName, lastName, password, deposit);
            AccountDb.AddAccount(account);
        }
    }



    class Program
    {
        public static void Main(string[] args)
        {
            bool on = true;
            Console.WriteLine("Hello, welcome to the Personal Finance Tracker.");
            Console.WriteLine("In this program, you can track your income and expenses.\n\n\n");

            AccountDB accountDB = new();
            accountDB.LoadAccounts();
            AccountManager accountManager = new(accountDB);

            while (on)
            {

            Console.WriteLine("1. Create account");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. exit");

            int erg = int.Parse(Console.ReadLine());

            if (typeof(int) == erg.GetType())
            {
                switch (erg)
                {
                    case 1:
                        accountManager.AccountCreator();
                        break;
                    
                    case 2:
                        Login();
                        break;
                    
                    case 3:
                        on = false;
                        break;
                
                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                        break;
                }
            }else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }


            }


            Console.WriteLine("Thank you for using the Personal Finance Tracker. Goodbye!");
        }


        private static void Login()
        {
            AccountDB accountDB = new();
            accountDB.LoadAccounts();
            bool logedIn = false;
            bool atempt = true;
            while (atempt)
            {
                Console.Clear();
                Console.WriteLine("write your ID");
                Console.WriteLine("or type 'Exit' to exit");
                Console.Write(" > ");

                string input = Console.ReadLine();

                if (input == "Exit" || input == "exit") return;
                
                
                int id = int.TryParse(input, out id) ? id : 0;

                foreach (var item in accountDB.Accounts)
                {
                    if (item.Id == id)
                    {
                        Console.WriteLine("write your password");
                        if (item.Password == Console.ReadLine())
                        {
                            logedIn = true;
                            atempt = false;
                            Console.WriteLine("Login successful");
                            LogedIn(item);
                        }else
                        {
                            Console.WriteLine("wrong password");
                            continue;
                        }

                    }
                }
                if(!logedIn)
                {
                Console.WriteLine("ID not found, try again");
                Console.ReadKey();
                }
            }
        }
        static void LogedIn(CreateAccount accountDB)
        {
            bool logOut = false;

                Console.WriteLine($"hello welcome back {accountDB.FirstName} to the personal finance tracker");
            while (!logOut)
            {
                Console.WriteLine("1. Make a transaction");
                Console.WriteLine("2. Account info");
                Console.WriteLine("3. Log out");
                
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        
                        //CreateTransaction(accountDB);
                        break;
                    case "2":
                        accountDB.AccountInfo();
                        break;
                    case "3":
                        logOut = true;
                        break;

                }
                Console.Clear();
            }

        }

    }
}
