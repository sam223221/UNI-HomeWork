# UNI-HomeWork


Personal Finance Tracker
Overview
The Personal Finance Tracker is a console application designed to help users manage their personal finances by tracking income and expenses. It allows users to create accounts, log in, and perform various financial operations. The application is built using C# and utilizes JSON for data storage.

Features

Account Creation

Users can create an account by providing their first name, last name, password, and an initial deposit.
Each account is assigned a unique ID automatically.
Account details, including the unique ID, first name, last name, and balance, can be viewed by the account holder.


Data Persistence
Accounts are stored in a JSON file, ensuring that user data is persisted between sessions.
Upon application start, existing accounts are loaded from the JSON file, allowing returning users to log in with their credentials.
Account Management
The application supports basic account management functions, including account creation and viewing account information.
Users can log in to their accounts by providing their unique ID and password.


User Interaction
The application operates through a console interface, prompting users for inputs and displaying relevant information based on their actions.
Error handling is implemented for user inputs, ensuring that the application can handle unexpected or incorrect inputs gracefully.
Technical Details
Classes and Methods


CreateAccount
Represents an individual user account with properties for first name, last name, password, balance, and ID.
Supports JSON serialization for data persistence.


AccountDB
Manages a collection of CreateAccount objects.
Handles the addition of new accounts, saving accounts to a JSON file, and loading accounts from the JSON file.
AccountManager
Facilitates account creation through user interaction in the console.
Utilizes AccountDB for storing newly created accounts.


Program
Contains the Main method, which is the entry point of the application.
Manages the application flow, including account creation, user login, and application exit.


Data Storage
Account data is serialized to JSON and stored in a file, making it persistent across application sessions.
The JSON file is read at the application start to load existing accounts, and it is updated whenever a new account is added.
Usage
To use the Personal Finance Tracker:

Start the application to be greeted by the welcome message and menu options.
Choose to create an account or log in if you are a returning user.
Follow the on-screen prompts to enter the required information for account creation or login.
Once logged in, you can view your account information or perform other available actions as per the provided options.
Requirements
.NET Framework or .NET Core to run C# applications.
Basic understanding of console applications and interaction.
Future Enhancements
Implement transaction functionality to allow users to record income and expenses.
Enhance account management features, such as updating account details and password.
Improve data security, especially for sensitive information like passwords.