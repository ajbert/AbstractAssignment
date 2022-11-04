using AbstractAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSearch.Models
{
    public abstract class MediaFile<T> where T : Media
    {
        
        public List<T> MediaList { get; set; }
        public string FilePath { get; set; }
        
        public List<T> Search(string searchTitle)
        {   
            
            return MediaList.Where(m => m.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
