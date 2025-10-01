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
            BooksInLibrary();
        }

        static void BooksInLibrary()
        {
            foreach (string[] book in books)
            {
                Console.WriteLine($"{book[0]}. {book[1]}: {book[2]} st.");
            }
        }
    }
}
