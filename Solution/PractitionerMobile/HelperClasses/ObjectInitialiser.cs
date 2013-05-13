using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractitionerMobile.HelperClasses
{
    public static class ObjectInitialiser
    {
        #region Patient Fields
        private static string[] _patientNames = new string[]
        {
            "Berta Ransch",
            "Julia Hafner",
            "Hans Huber",             
            "Franz Fischer", 
            "Karl Gruber",
            "Kurt Frisch",
            "Marianne Grabner",
            "Max Muster",
            "Rosalie Gmunder", 
            "Xaver Neuner"
        };

        private static DateTime[] _patientLastOrdinations = new DateTime[]
        {
            DateTime.Now.AddDays(-3),
            DateTime.Now.AddDays(-8),
            DateTime.Now.AddDays(-12),
            DateTime.Now.AddDays(-17),
            DateTime.Now.AddDays(-5),
            DateTime.Now.AddDays(-50),
            DateTime.Now.AddDays(-21),
            DateTime.Now.AddDays(-6),
            DateTime.Now.AddDays(-9),
            DateTime.Now.AddDays(-1),
        };
        #endregion

        #region Medicament Fields
        private static string[] _medicamentNames = new string[]
        {
            "ABC Pflaster (sensitiv)",
            "Diclabeta",
            "Diclac Schmerzgel",
            "Dolormin Mobil Gel",
            "Finalgon",
            "Hepa-Gel",
            "Heparin",
            "ibutop",
            "Kytta-Balsam",
            "Kytta-Salbe",
            "Mobilat DuoA",
            "Mobilat Intens",
            "Proff",
            "Reparil-Gel",
            "Schmerzsalbe",            
            "Thrombophob",
            "Traumaplant",
            "Traumon",
            "Traumeel",
            "Venalitan 150000",
            "Voltaren Emulgel",
            "Schmerzgel"
        };
        #endregion

        /// <summary>
        /// Creates a collection of patients and returns it.
        /// </summary>
        /// <returns></returns>
        internal static ObservableCollection<Patient> CreatePatients()
        {
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

            // Create names
            foreach (string name in _patientNames)
            {
                patients.Add(new Patient(name));
            }

            // Create last ordination date
            for(int i=0; i < _patientLastOrdinations.Count(); i++)
            {
                patients[i].LastOrdination = _patientLastOrdinations[i];
            }

            return patients;
        }

        /// <summary>
        /// Creates a collection of medicaments and returns it.
        /// </summary>
        /// <returns></returns>
        internal static ObservableCollection<Medicament> CreateMedicaments()
        {
            ObservableCollection<Medicament> medicaments = new ObservableCollection<Medicament>();

            foreach (string name in _medicamentNames)
            {
                medicaments.Add(new Medicament(name));
            }

            return medicaments;
        }
    }
}
