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
        
        /// <summary>
        /// Gets or sets the name of the medicament.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the medicament.
        /// </summary>
        public string Description { get; set; }
    }
}
