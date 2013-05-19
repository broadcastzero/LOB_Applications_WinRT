using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PractitionerMobile.BusinessObjects
{
    public class Patient
    {
        public Patient(string name)
        {
            this.Name = name;
            this.Ordinations = new List<Ordination>();
        }

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a list of the doctors collected ordinations at this particular patient.
        /// </summary>
        public List<Ordination> Ordinations { get; set; }

        public DateTime LastOrdination { get; set; }
    }
}
