using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PractitionerMobile.BusinessObjects;
using PractitionerMobile.HelperClasses;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using CustomBaseButton = PractitionerMobile.Controls.ButtonBase;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
namespace PractitionerMobile
{
    /// <summary>
    /// The main page of this application.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Set DataContext in order to be able to databind to properties of this class
            DataContext = this;

            // Fill lists with values
            this.Patients = PatientInitialiser.Create();
            this.Medicaments = MedicamentInitialiser.Create();

            // Initialise the list of ordination for a certain date and patient.
            this.OrdinationsOfPatientAndDate = new ObservableCollection<Ordination>();

            // Create dropdown with Patient / Medicametion selection
            this.InitialiseFieldList();

            // Declare that this view can be used as a sharing source
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += OnDataRequested;
        }

        #region Public Properties
        public ObservableCollection<Patient> Patients
        {
            get;
            set;
        }

        public ObservableCollection<Medicament> Medicaments
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// Initialises the ComboBox in which the user can select if he wants patients or medicaments displayed
        /// </summary>
        private void InitialiseFieldList()
        {
            this.FieldSelector.Items.Add("Patienten");
            this.FieldSelector.Items.Add("Medikamente");
                 
            this.FieldSelector.SelectedIndex = 0;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        /// <summary>
        /// This is the code which sets the custom toggle button 'ButtonBase'.
        /// It is not used within the application, but could be used, if the button would be used.
        /// </summary>
        private void baseButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CustomBaseButton button = (sender as CustomBaseButton);

            if(button.IsPressed)
            {
                button.SetValue(CustomBaseButton.IsPressedProperty, false);
            }
            else
            {
                button.SetValue(CustomBaseButton.IsPressedProperty, true);
            }
        }

        /// <summary>
        /// Changes the binding Patient vs. Medicament details
        /// </summary>
        private void ChangeContentDependingOnSelectedListEntry(object sender, SelectionChangedEventArgs e)
        {            
            ComboBox combobox = (sender as ComboBox);

            if (combobox.SelectedIndex < 0)
                return;

            switch(combobox.SelectedIndex)
            {
                case 0: this.ElementPanel.ItemsSource = this.Patients;
                    // Elements of first column
                    this.MedicamentDetails.Visibility = Visibility.Collapsed;
                    this.PatientDetails.Visibility = Visibility.Visible;

                    // Elements of second column
                    this.PatientOrdinationMask.Visibility = Visibility.Visible;
                    this.MedicationSecondColumn.Visibility = Visibility.Collapsed;

                    // Elements of third column
                    this.PatientAppointmentCalender.Visibility = Visibility.Visible;
                    this.ListedOrdinations.Visibility = Visibility.Visible;
                    this.MedicationThirdColumn.Visibility = Visibility.Collapsed;
                    break;

                case 1: this.ElementPanel.ItemsSource = this.Medicaments;
                    // Elements of first column
                    this.PatientDetails.Visibility = Visibility.Collapsed;
                    this.MedicamentDetails.Visibility = Visibility.Visible;

                    // Elements of second column
                    this.PatientOrdinationMask.Visibility = Visibility.Collapsed;
                    this.MedicationSecondColumn.Visibility = Visibility.Visible;

                    // Elements of third column
                    this.PatientAppointmentCalender.Visibility = Visibility.Collapsed;
                    this.ListedOrdinations.Visibility = Visibility.Collapsed;
                    this.MedicationThirdColumn.Visibility = Visibility.Visible;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// This method is called when the selection of the field (Patient / Medicament / ...) has changed.
        /// </summary>
        private void OnFieldSelectorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ChangeContentDependingOnSelectedListEntry(sender, e);
        }

        private async void SaveOrdinationEntry(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("ok button hit");

            Ordination ordination = new Ordination();
            ordination.Date = DateTime.Today;
            ordination.SocialInsurance = this.PatientOrdinationMask.SocialInsurance;
            ordination.DurationMinutes = this.PatientOrdinationMask.DurationMinutes;
            ordination.Diagnosis = this.PatientOrdinationMask.Diagnosis;

            string message = "Die Ordination wurde erfolgreich gespeichert.";

            try
            {
                Patient selectedPatient = Patients.Where(p => p.Name == (this.ElementPanel.SelectedItem as Patient).Name).FirstOrDefault();
                selectedPatient.Ordinations.Add(ordination);
                GetOrdinationsForDateAndPatient();

            }
            catch (NullReferenceException)
            {
                message = "Bitte wählen Sie zuerst einen Patienten aus!";
            }

            MessageDialog dialog = new MessageDialog(message, "Speichern einer Ordination");
            await dialog.ShowAsync();
        }

        /// <summary>
        /// In here, custom logic could be implemented for the case that the cancel button of the custom control is hit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOrdinationEntry(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("cancel button hit");
        }

        /// <summary>
        ///  Gets or sets the ordinations of a patient on a certain date.
        /// </summary>
        public ObservableCollection<Ordination> OrdinationsOfPatientAndDate { get; set; }

        private void GetOrdinationsForDateAndPatient()
        {
            var ordinationsOfPatientAndDate = new List<Ordination>();
            Patient selectedPatient;

            try
            {
                selectedPatient = Patients.Where(p => p.Name == (this.ElementPanel.SelectedItem as Patient).Name).FirstOrDefault();
            }
            catch (NullReferenceException)
            {
                // Either no patient is selected, or the medicament panel is selected.
                this.OrdinationsOfPatientAndDate.Clear();
                return;
            }

            ordinationsOfPatientAndDate = selectedPatient.Ordinations.Where(o => o.Date == DateTime.Today).ToList();

            this.OrdinationsOfPatientAndDate.Clear();

            foreach (Ordination ordination in ordinationsOfPatientAndDate)
            {
                this.OrdinationsOfPatientAndDate.Add(ordination);
            }
        }

        private void PatientAppointmentCalender_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GetOrdinationsForDateAndPatient();
        }

        private void PatientChanged(object sender, SelectionChangedEventArgs e)
        {
            GetOrdinationsForDateAndPatient();
        }

        #region Sharing
        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            // Get selected patient
            Patient selectedPatient;
            try
            {
                selectedPatient = Patients.Where(p => p.Name == (this.ElementPanel.SelectedItem as Patient).Name).FirstOrDefault();
            }
            catch(NullReferenceException)
            {
                // No patient selected - nothing to share
                return;
            }

            // Shown data in Share pane
            args.Request.Data.Properties.Title = selectedPatient.Name;
            args.Request.Data.Properties.Description = "Last ordination: " + selectedPatient.LastOrdination;

            // Ordination data
            StringBuilder textToSet = new StringBuilder();
            textToSet.AppendLine("Ordinations:");

            foreach(Ordination o in selectedPatient.Ordinations)
            {
                textToSet.AppendLine( o.Date.ToString() + ", " + o.SocialInsurance + ", " + o.DurationMinutes + "Minutes, " + o.Diagnosis);
                textToSet.AppendLine("---");
            }

            args.Request.Data.SetText(textToSet.ToString());
        }
        #endregion
    }
}
