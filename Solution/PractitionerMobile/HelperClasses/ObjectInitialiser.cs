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
        private static string[] patientNames = new string[]
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

        private static string[] medicamentNames = new string[]
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

        /// <summary>
        /// Creates a collection of patients and returns it.        /// 
        /// </summary>
        /// <returns></returns>
        internal static ObservableCollection<Patient> CreatePatients()
        {
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

            foreach (string name in patientNames)
            {
                patients.Add(new Patient(name));
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

            foreach (string name in medicamentNames)
            {
                medicaments.Add(new Medicament(name));
            }

            return medicaments;
        }
    }
}
