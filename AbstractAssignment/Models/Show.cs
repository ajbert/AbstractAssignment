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

        public override string Display()
        {
            return $"ID: {Id}\nTitle: {Title}\nEpisodes: {Episode}\nSeasons: {Season}\nWriters: {Writers}\n";
        }

        
    }
}
