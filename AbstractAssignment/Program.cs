using System;

namespace AbstractAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {

                Console.WriteLine("Which media type would you like displayed?");
                Console.WriteLine("1. Movies");
                Console.WriteLine("2. Shows");
                Console.WriteLine("3. Videos");
                Console.WriteLine("x. Exit");
                Console.Write("> ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine(" \n Displaying Movies: \n");

                        Media movies = new Movie();
                        movies.Read();
                        movies.Display();
                                          
                        break;
                    case "2":
                        Console.WriteLine("\n Displaying Shows: \n");
                        Media shows = new Show();
                        shows.Read();
                        shows.Display();
                        break;
                    case "3":
                        Console.WriteLine("\n Displaying Videos: \n");
                        Media videos = new Video();
                        videos.Read();
                        videos.Display();
                        break;

                    case "x":
                        Console.WriteLine("\n Goodbye");
                        break;

                    default:
                        Console.WriteLine("Please Choose 1, 2, 3 or x");
                        break;
                }

            } while (input != "x"); 

        }
    }
}
