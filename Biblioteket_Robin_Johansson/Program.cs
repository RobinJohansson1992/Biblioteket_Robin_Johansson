using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;

namespace Biblioteket_Robin_Johansson
{
    internal class Program
    {
        static string[][] books =
            [
                ["1", "Harry Potter"],
                ["2", "Sagan om ringen"],
                ["3", "Bamse i trollskogen"],
                ["4", "Throne of glass"],
                ["5", "A song of ice and fire"],
            ];

        static int[] booksInStore =
            [     2, // Harry Potter
                  3, // Sagan om ringen
                  5, // Bammse i trollskogen
                  1, // Throne of glass
                  2  // A song of ice and fire
            ];

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
                    //return book
                    break;

                case 4:
                    //Display loans
                    break;

                case 5:
                    Console.WriteLine("\nDu loggas ut...");
                    Console.ReadLine();
                    LogIn();
                    break;
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

            switch (userInput)
            {
                case 1:
                    booksInStore[0] -= 1 ;
                    Console.WriteLine($"Du lånade boken {books[0][1]}!");
                    Console.WriteLine($"Det är nu {booksInStore[0]} ex av {books[0][1]} kvar i butiken.");
                    break;

                case 2:
                    booksInStore[1] -= 1 ;
                    Console.WriteLine($"Du lånade boken {books[1][1]}!");
                    Console.WriteLine($"Det är nu {booksInStore[1]} ex av {books[1][1]} kvar i butiken.");
                    break;

                case 3:
                    booksInStore[2] -= 1 ;
                    Console.WriteLine($"Du lånade boken {books[2][1]}!");
                    Console.WriteLine($"Det är nu {booksInStore[2]} ex av {books[2][1]} kvar i butiken.");
                    break;

                case 4:
                    booksInStore[3] -= 1 ;
                    Console.WriteLine($"Du lånade boken {books[3][1]}!");
                    Console.WriteLine($"Det är nu {booksInStore[3]} ex av {books[3][1]} kvar i butiken.");
                    break;

                case 5:
                    booksInStore[4] -= 1 ;
                    Console.WriteLine($"Du lånade boken {books[4][1]}!");
                    Console.WriteLine($"Det är nu {booksInStore[4]} ex av {books[4][1]} kvar i butiken.");
                    break;
            }

            Console.ReadLine();

            MainMenu();
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
                //if the user gets it right, unlock the menu (success = true):
                if (success)
                {
                    Console.WriteLine($"välkommen {userName}!");
                    Console.WriteLine("Tryck enter för att gå till menyn");
                    Console.ReadLine();
                    MainMenu();
                    success = true;
                }
                //For every attempt 'attempts' subtracts by -1:
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
