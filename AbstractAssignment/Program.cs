using MovieSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractAssignment
{
    internal class Program
    {
       public static void Main(string[] args)
            
        {
            var movieFileName = "movies.csv";
            var videoFileName = "videos.csv";
            var showFileName = "shows.csv";

            MediaFile<Movie> movieFile = new MovieFile(movieFileName);
            MediaFile<Video> videoFile = new VideoFile(videoFileName);
            MediaFile<Show> showFile = new ShowFile(showFileName);
            string input;

            do
            {

                Console.WriteLine("Which media type would you like displayed?");
                Console.WriteLine("1. Movies");
                Console.WriteLine("2. Shows");
                Console.WriteLine("3. Videos");
                Console.WriteLine("4. Search by title");
                Console.WriteLine("x. Exit");
                Console.Write("> ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine(" \n Displaying Movies: \n");

                        foreach (var m in movieFile.MediaList) Console.WriteLine(m.Display());
                                          
                        break;
                    case "2":
                        Console.WriteLine("\n Displaying Shows: \n");
                        foreach (var m in showFile.MediaList) Console.WriteLine(m.Display());

                        break;
                    case "3":
                        Console.WriteLine("\n Displaying Videos: \n");

                        foreach (var m in videoFile.MediaList) Console.WriteLine(m.Display());
                                               
                        break;
                        
                    case "4":
                        
                        Console.WriteLine("\nEnter title");                  
                        var searchTitle = Console.ReadLine();
                        

                        var results = new List<Media>();
                        

                        results.AddRange(movieFile.Search(searchTitle));
                        results.AddRange(videoFile.Search(searchTitle));
                        results.AddRange(showFile.Search(searchTitle));

                        int searchCount = results.Count();

                        Console.WriteLine($"The search found {searchCount} instances of titles containing {searchTitle}.\n");

                        foreach (var item in results) Console.WriteLine(item.Display());
                        break;

                    case "x":
                        Console.WriteLine("\n Goodbye");
                        break;

                    default:
                        Console.WriteLine("Please Choose 1, 2, 3, 4 or x");
                        break;
                }

            } while (input != "x"); 

        }
    }
}
