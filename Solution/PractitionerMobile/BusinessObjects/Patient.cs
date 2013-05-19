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

        /// <summary>
        /// Gets or sets the name of the patient.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a list of the Doctors collected ordinations at this particular patient.
        /// </summary>
        public List<Ordination> Ordinations { get; set; }

        /// <summary>
        /// Gets or sets the DateTime of the last ordination of this patient.
        /// </summary>
        public DateTime LastOrdination { get; set; }
    }
}
