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

        static void Main(string[] args)
        {
            BooksInLibrary();
        }

        static void BooksInLibrary()
        {
            foreach (string[] book in books)
            {
                Console.WriteLine($"{book[0]}. {book[1]}");
            }
        }
    }
}
