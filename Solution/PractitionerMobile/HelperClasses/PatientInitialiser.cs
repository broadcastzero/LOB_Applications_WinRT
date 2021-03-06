﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using PractitionerMobile.BusinessObjects;
using Windows.UI.Xaml.Media.Imaging;

namespace PractitionerMobile.HelperClasses
{
    public static class PatientInitialiser
    {
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

        private static string[] _pathToImage = new string[]
        {
            "ms-appx:///Assets/Patients/bertaransch.png",
            "ms-appx:///Assets/Patients/juliahafner.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png"
        };

        /// <summary>
        /// Creates a collection of patients and returns it.
        /// </summary>
        internal static ObservableCollection<Patient> Create()
        {
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

            // Create names
            foreach (string name in _patientNames)
            {
                patients.Add(new Patient(name));
            }

            // Create last ordination date
            for (int i=0; i < _patientLastOrdinations.Count(); i++)
            {
                patients[i].LastOrdination = _patientLastOrdinations[i];
            }

            // Create image
            for (int i=0; i < _pathToImage.Count(); i++)
            {
                patients[i].Picture = new BitmapImage(new Uri(_pathToImage[i]));
            }
            
            return patients;
        }
    }
}
