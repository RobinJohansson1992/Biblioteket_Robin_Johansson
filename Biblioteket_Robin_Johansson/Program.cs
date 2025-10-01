using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;

namespace Biblioteket_Robin_Johansson
{
    internal class Program
    {
        static string[][] books =
            [
                ["1", "Harry Potter", "2"],
                ["2", "Sagan om ringen", "3"],
                ["3", "Bamse i trollskogen", "5"],
                ["4", "Throne of glass", "1"],
                ["5", "A song of ice and fire", "2"],
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

            BooksInLibrary();
        }

        //Login method:
        static void LogIn()
        {
            Console.WriteLine("Välkommen till biblioteket!");
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
                    Console.WriteLine($"välkommen {userName}");
                    Console.WriteLine("Tryck enter för att gå till menyn");
                    Console.ReadLine();
                    success = true;
                }
                //For every attempt 'attempts' subtracts by -1:
                else
                {
                    Console.WriteLine("Ogiltigt användarnamn eller lösenord.");
                    attempts--;
                }
                //If attempts are 0, the user does not get to try again without restartting the program:
                if (attempts <1)
                {
                    Console.WriteLine("Du lyckades inte logga in på 3 försök.");
                    Console.WriteLine("Programmet avslutas...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

            }

        }

        static void BooksInLibrary()
        {
            Console.Clear();

            foreach (string[] book in books)
            {
                Console.WriteLine($"{book[0]}. {book[1]}: {book[2]} st.");
            }
        }
    }
}
