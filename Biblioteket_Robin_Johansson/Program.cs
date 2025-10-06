using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;

namespace Biblioteket_Robin_Johansson
{
    internal class Program
    {
        // Contains the books in the library:
        static string[][] books =
            [
                ["1", "Harry Potter"],
                ["2", "Sagan om ringen"],
                ["3", "Bamse i trollskogen"],
                ["4", "Throne of glass"],
                ["5", "A song of ice and fire"],
            ];

        // Contains how many of each book there are in store:
        static int[] booksInStore =
            [     2, // Harry Potter
                  3, // Sagan om ringen
                  5, // Bamse i trollskogen
                  1, // Throne of glass
                  2  // A song of ice and fire
            ];

        // Stores how many of each book the user has on loan.
        static int[] loanedBooks =
            [
                  0, // Harry Potter
                  0, // Sagan om ringen
                  0, // Bammse i trollskogen
                  0, // Throne of glass
                  0  // A song of ice and fire
            ];

        // Contains the authorised users and their pin-codes:
        static string[][] users =
            [
                ["Yoda", "1337"],
                ["Chewwy", "1111"],
                ["Luke", "9988"],
                ["Leia", "4545"],
                ["Han", "1234"],
            ];

        static void Main(string[] args)
        {

            LogIn();

        }

        //Method that displays the main menu:
        static void MainMenu()
        {
            Console.Clear();

            Console.WriteLine("Välj i listan vad du vill göra: \n");
            Console.WriteLine("1. Visa böcker");
            Console.WriteLine("2. Låna bok");
            Console.WriteLine("3. Lämna tillbaka bok");
            Console.WriteLine("4. Mina lån");
            Console.WriteLine("5. Logga ut");

            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 5)
            {
                Console.WriteLine("Du måste ange ett nummer från listan.");
            }


            switch (userInput)
            {
                case 1:
                    BooksInLibrary();
                    break;

                case 2:
                    LoanBooks();
                    break;

                case 3:
                    ReturnBooks();
                    break;

                case 4:
                    DisplayLoans();
                    break;

                case 5:
                    Console.WriteLine("\nDu loggas ut...");
                    Console.ReadLine();
                    LogIn();
                    break;
            }
        }

        //Display loans method:
        static void DisplayLoans()
        {
            Console.Clear();
            bool loans = false;

            //Looks through every book in "books".
            for (int i = 0; i < books.Length; i++)
            {
                //book stores every individual book
                string[] book = books[i];
                //onLoan stores current value of every book from "loanedBooks"
                int onLoan = loanedBooks[i];

                //If there are any books on loan, display that book and how many is on loan:
                if (onLoan > 0)
                {
                    loans = true;
                    Console.WriteLine($"{book[1]}: {onLoan} ex.");
                }
            }

            //If there are no current loans, display this message:
            if (!loans)
            {
                Console.WriteLine("Du har inga lån just nu.");
            }

            Console.ReadLine();
            MainMenu();
        }

        //Return books method:
        static void ReturnBooks()
        {
            Console.Clear();
            Console.WriteLine("Ange index-nummer på boken du vill lämna tillbaka:\n");

            //Forloop looks through the books in books:
            for (int i = 0; i < books.Length; i++)
            {
                //Array book stores each book in books
                string[] book = books[i];
                //onLoan stores the current value of every book 
                int onLoan = loanedBooks[i];

                //If the user dont have a book on loan, dont display that book.
                if (onLoan > 0)
                {
                    Console.WriteLine($"{book[0]}. {book[1]}: {onLoan} st.");
                }
            }

            int userInput;

            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput <= 0 || userInput > 5)
            {
                Console.WriteLine("Du måste ange index-nummer till boken du vill lämna tillbaka.");
            }

            // User input -1 because the array begins on 0.
            int bookIndex = userInput - 1;

            if (loanedBooks[bookIndex] > 0)
            {
                Console.WriteLine($"Du lämnade tillbaka boken {books[bookIndex][1]}.");
                Console.WriteLine($"Det finns nu {booksInStore[bookIndex] + 1} ex av boken i biblioteket.");
                booksInStore[bookIndex]++;
                loanedBooks[bookIndex]--;
                Console.ReadLine();
                MainMenu();
            }
            else
            {
                Console.WriteLine($"Du har inte ett aktivt lån av {books[bookIndex][1]} just nu.");
                Console.WriteLine("Tryck enter för att återgå till huvudmenyn.");
                Console.ReadLine();
                MainMenu();
            }
        }

        //Loan books method:
        static void LoanBooks()
        {
            Console.Clear();
            Console.WriteLine("Ange index-nummer på boken du vill låna.");

            int userInput;


            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 5)
            {
                Console.WriteLine("Du måste ange ett nummer från listan.");
            }

            // User input -1 because the array begins on 0.
            int bookIndex = userInput - 1;

            if (booksInStore[bookIndex] > 0)
            {
                Console.WriteLine($"Du lånade boken {books[bookIndex][1]}.");
                Console.WriteLine($"Det finns nu {booksInStore[bookIndex] - 1} ex av boken i biblioteket.");
                booksInStore[bookIndex]--;
                loanedBooks[bookIndex]++;
                Console.ReadLine();
                MainMenu();
            }
            else
            {
                Console.WriteLine($"Det finns tyvärr inga ex. kvar av {books[bookIndex][1]} just nu.");
                Console.ReadLine();
                MainMenu();
            }

        }

        //Login method:
        static void LogIn()
        {
            Console.Clear();
            Console.WriteLine("Välkommen till biblioteket!\n");
            Console.WriteLine("Vänligen ange användarnamn och pinkod för att logga in:");

            bool success = false;

            int attempts = 3;

            //Loop that allows the user three attemps to log in:
            while (!success)
            {

                Console.Write("Användarnamn:");
                string userName = Console.ReadLine();
                Console.Write("Pinkod:");
                string pinCode = Console.ReadLine();

                //Compare each user in users if the username and pincode match:
                foreach (var user in users)
                {
                    if (user[0] == userName && user[1] == pinCode)
                    {
                        success = true;
                        break;
                    }
                }
                //if the user gets it right, unlock the main menu (success = true):
                if (success)
                {
                    Console.WriteLine($"Välkommen {userName}!");
                    Console.WriteLine("Tryck enter för att gå till menyn");
                    Console.ReadLine();
                    MainMenu();
                    success = true;
                }
                //For every failed login, 'attempts' subtracts by -1:
                else
                {
                    Console.WriteLine("\nOgiltigt användarnamn eller lösenord.");
                    attempts--;
                }
                //If attempts are 0, the user does not get to try again without restartting the program:
                if (attempts < 1)
                {
                    Console.WriteLine("\nDu lyckades inte logga in på 3 försök.");
                    Console.WriteLine("Programmet avslutas...");
                    Environment.Exit(0);
                }

            }

        }

        //Method that displays the books in the library:
        static void BooksInLibrary()
        {
            Console.Clear();


            for (int i = 0; i < books.Length; i++)
            {
                string[] book = books[i];
                int inStore = booksInStore[i];

                Console.WriteLine($"{book[0]}. {book[1]}: {inStore} st.");

            }
            Console.WriteLine("\nTryck enter för att återgå till huvudmenyn.");
            Console.ReadLine();
            MainMenu();
        }
    }
}
