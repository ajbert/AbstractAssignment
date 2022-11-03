using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractAssignment
{
    public class Video : Media
    {   public string Format { get; set; }
        public int Length { get; set; }
        
        public int[] Regions { get; set; }
        
        public string Region {get; set; }
        


        public override string Display()
        {
            return $"ID: {Id}\nTitle: {Title}\nFormat {Format}\nLength: {Length}\nRegions: {Region}\n";
            
        }
    

        
    }
}
