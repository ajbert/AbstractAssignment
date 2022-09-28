using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractAssignment
{
    public class Movie : Media
    {
        List<int> movieIds = new List<int>();
        List<string> movieTitles = new List<string>();
        List<string> movieGenres = new List<string>();
        public string Genres { get; set; }

        public override void Display()
        {
            for (int i = 0; i < movieIds.Count; i++)
            {
                // display movie details
                Console.WriteLine($"Id: {movieIds[i]}");
                Console.WriteLine($"Title: {movieTitles[i]}");
                Console.WriteLine($"Genre(s): {movieGenres[i]}");
                Console.WriteLine();
            }
        }

        public override void Read()
        {
            
            StreamReader sr = new StreamReader("movies.csv");
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                // first look for quote(") in string
                // this indicates a comma(,) in movie title
                int idx = line.IndexOf('"');
                if (idx == -1)
                {
                    // no quote = no comma in movie title
                    // movie details are separated with comma(,)
                    string[] movieDetails = line.Split(',');
                    // 1st array element contains movie id
                    movieIds.Add(int.Parse(movieDetails[0]));
                    // 2nd array element contains movie title
                    movieTitles.Add(movieDetails[1]);
                    // 3rd array element contains movie genre(s)
                    // replace "|" with ", "
                    movieGenres.Add(movieDetails[2].Replace("|", ", "));
                }
                else
                {
                    // quote = comma in movie title
                    // extract the movieId
                    movieIds.Add(int.Parse(line.Substring(0, idx - 1)));
                    // remove movieId and first quote from string
                    line = line.Substring(idx + 1);
                    // find the next quote
                    idx = line.IndexOf('"');
                    // extract the movieTitle
                    movieTitles.Add(line.Substring(0, idx));
                    // remove title and last comma from the string
                    line = line.Substring(idx + 2);
                    // replace the "|" with ", "
                    movieGenres.Add(line.Replace("|", ", "));
                }
            }
            // close file when done
            sr.Close();
        }
    }
}
