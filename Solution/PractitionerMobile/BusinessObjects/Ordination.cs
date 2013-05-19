using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractitionerMobile.BusinessObjects
{
    /// <summary>
    /// An ordination of a patient.
    /// </summary>
    public class Ordination
    {
        /// <summary>
        /// Gets or sets the date of the ordination.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets information about how long the ordination has lasted (in Minutes).
        /// </summary>
        public int DurationMinutes { get; set; }

        /// <summary>
        /// The Diagnosis of the Ordination.
        /// </summary>
        public string Diagnosis { get; set; }

        /// <summary>
        /// Gets or sets the name of the patients social insurance.
        /// </summary>
        public string SocialInsurance { get; set; }

    }
}
