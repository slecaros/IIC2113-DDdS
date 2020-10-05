using System;

namespace PracticeI1
{
    class Program
    {
        static void Main(string[] args)
        {
            PagesAdapter imdb = new IMDB();
            imdb.ReadData();
            Console.WriteLine("Hello World!");
        }
    }
}
