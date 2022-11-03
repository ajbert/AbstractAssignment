using AbstractAssignment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSearch.Models
{
    public class ShowFile : MediaFile<Show>
    {
        public ShowFile(string path)
        {
            MediaList = new List<Show>();
            FilePath = path;

            try
            {
                StreamReader sr = new StreamReader(FilePath);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {   
                    Show show = new Show();
                    string line = sr.ReadLine();
                    // first look for quote(") in string
                    // this indicates a comma(,) in show title
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma in show title
                        // movie details are separated with comma(,)
                        string[] movieDetails = line.Split(',');
                        // 1st element contains show id
                        show.Id = int.Parse(movieDetails[0]);
                        // 2nd element contains show title
                        show.Title = movieDetails[1];

                        //3rd element contains episodes
                        show.Episode = int.Parse(movieDetails[2]);
                        // 4th element contaians seasons
                        show.Season = int.Parse(movieDetails[3]);

                        // 5th array element contains show writers(s)
                        // replace "|" with ", "
                        show.Writers = movieDetails[4].Replace("|", ", ");
                    }
                    MediaList.Add(show);
                }
                // close file when done
                sr.Close();

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
