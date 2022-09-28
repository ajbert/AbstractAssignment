using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractAssignment
{
    internal class Video : Media
    {   public string Format { get; set; }
        public int Length { get; set; }
        
        public int[] Regions { get; set; }

        List<int> videoIds = new List<int>();
        List<string> videoTitles = new List<string>();
        List<string> videoFormats = new List<string>();
        List<int> videoLengths = new List<int>();
        List<string> videoRegions = new List<string>();
        


        public override void Display()
        {
            for (int i = 0; i < videoIds.Count; i++)
            {
                // display video details
                Console.WriteLine($"Id: {videoIds[i]}");
                Console.WriteLine($"Title: {videoTitles[i]}");
                Console.WriteLine($"Format(s): {videoFormats[i]}");
                Console.WriteLine($"Length: {videoLengths[i]}");
                Console.WriteLine($"Region(s): {videoRegions[i]}");
                Console.WriteLine();
            }
        }
    

        public override void Read()
        {
            StreamReader sr = new StreamReader("videos.csv");
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
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
                    videoIds.Add(int.Parse(movieDetails[0]));
                    // 2nd array element contains video title
                    videoTitles.Add(movieDetails[1]);

                    //3rd array element contains formats
                    videoFormats.Add(movieDetails[2].Replace("|", ", "));

                    
                    // 4th array element contaians seasons
                    videoLengths.Add(int.Parse(movieDetails[3]));

                    // 5th array element contains video regions(s)
                    // replace "|" with ", "
                    videoRegions.Add(movieDetails[4].Replace("|", ", "));
                }

            }
            // close file when done
            sr.Close(); ;
        }
    }
}
