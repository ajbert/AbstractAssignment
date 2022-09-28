using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractAssignment
{
    public class Show : Media
    {
        public int Episode { get; set; }
        public int Season { get; set; }
        public string Writers { get; set; }

        List<int> showIds = new List<int>();
        List<string> showTitles = new List<string>();
        List<int> showEpisodes = new List<int>();
        List<int> showSeasons = new List<int>();
        List<string> showWriters = new List<string>();

        public override void Display()
        {
            for (int i = 0; i < showIds.Count; i++)
            {
                // display movie details
                Console.WriteLine($"Id: {showIds[i]}");
                Console.WriteLine($"Title: {showTitles[i]}");
                Console.WriteLine($"Episodes: {showEpisodes[i]}");
                Console.WriteLine($"Seasons: {showSeasons[i]}");
                Console.WriteLine($"Writer(s): {showWriters[i]}");
                Console.WriteLine();
            }
        }

        public override void Read()
        {
            StreamReader sr = new StreamReader("shows.csv");
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                // first look for quote(") in string
                // this indicates a comma(,) in show title
                int idx = line.IndexOf('"');
                if (idx == -1)
                {
                    // no quote = no comma in show title
                    // movie details are separated with comma(,)
                    string[] movieDetails = line.Split(',');
                    // 1st array element contains show id
                    showIds.Add(int.Parse(movieDetails[0]));
                    // 2nd array element contains show title
                    showTitles.Add(movieDetails[1]);

                    //3rd array element contains episodes
                    showEpisodes.Add(int.Parse(movieDetails[2]));
                    // 4th array element contaians seasons
                    showSeasons.Add(int.Parse(movieDetails[3]));

                    // 5th array element contains show writers(s)
                    // replace "|" with ", "
                    showWriters.Add(movieDetails[4].Replace("|", ", "));
                }
                
            }
            // close file when done
            sr.Close();
        }
    }
}
