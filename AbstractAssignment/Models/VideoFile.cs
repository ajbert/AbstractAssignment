using AbstractAssignment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSearch.Models
{
    public class VideoFile : MediaFile<Video>
    {
        public VideoFile(string path)
        {
            MediaList = new List<Video>();
            FilePath = path;

            try
            {
                StreamReader sr = new StreamReader(FilePath);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {   
                    Video video = new Video();
                    string line = sr.ReadLine();
                    // first look for quote(") in string
                    // this indicates a comma(,) in video title
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma in video title
                        // movie details are separated with comma(,)
                        string[] movieDetails = line.Split(',');
                        // 1st array element contains video id
                        video.Id = int.Parse(movieDetails[0]);
                        // 2nd array element contains video title
                        video.Title = movieDetails[1];

                        //3rd array element contains formats
                        video.Format = movieDetails[2].Replace("|", ", ");


                        // 4th array element contaians seasons
                        video.Length = int.Parse(movieDetails[3]);

                        // 5th array element contains video regions(s)
                        // replace "|" with ", "
                        video.Region = movieDetails[4].Replace("|", ", ");
                    }
                    MediaList.Add(video);
                }
                // close file when done
                sr.Close(); ;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
