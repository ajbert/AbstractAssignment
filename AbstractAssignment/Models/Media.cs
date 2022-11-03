using System;
using System.Linq;
using System.Collections.Generic;

namespace AbstractAssignment
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }

       

        public abstract string Display();

        

        
    }
}
