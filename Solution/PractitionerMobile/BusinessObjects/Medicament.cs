using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PractitionerMobile
{
    public class Medicament
    {
        public Medicament(string name)
        {
            this.Name = name;
        }
        
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}
