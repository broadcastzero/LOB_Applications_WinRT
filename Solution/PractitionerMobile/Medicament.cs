using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PractitionerMobile
{
    public class Medicament
    {
        public string Name
        {
            get;
            set;
        }

        public Medicament(string name)
        {
            this.Name = name;
        }
    }
}
