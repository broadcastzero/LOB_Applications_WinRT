using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using PractitionerMobile.HelperClasses;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CustomBaseButton = PractitionerMobile.Controls.ButtonBase;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PractitionerMobile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Set DataContext in order to be able to databind to properties of this class
            DataContext = this;

            // Fill lists with values
            this.Patients = ObjectInitialiser.CreatePatients();
            this.Medicaments = ObjectInitialiser.CreateMedicaments();

            // Create dropdown
            this.InitialiseFieldList();
        }

        #region Public Fields
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
        /// Initialises the second ComboBox in which the user can select, results from which field should be displayed below.
        /// </summary>
        private void InitialiseFieldList()
        {
            this.fieldSelector.Items.Add("Patienten");
            this.fieldSelector.Items.Add("Medikamente");

            this.fieldSelector.SelectedIndex = 0;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

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

        private void ChangeListBinding(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = (sender as ComboBox);

            if (combobox.SelectedIndex < 0)
                return;

            switch(combobox.SelectedIndex)
            {
                case 0: this.elementPanel.ItemsSource = this.Patients;
                    break;
                case 1: this.elementPanel.ItemsSource = this.Medicaments;
                    break;
                default:
                    break;
            }
        }
    }
}
