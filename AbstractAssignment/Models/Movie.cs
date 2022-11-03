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
       
        public string Genres { get; set; }

        

        public override string Display()
        {
            return $"ID: {Id}\nTitle: {Title}\nGenres: {Genres}\n"; 
            
        }

        

            

    }
}
