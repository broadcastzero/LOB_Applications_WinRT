using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            this.initialiseAlphabeticList();
            this.initialiseFieldList();
        }

        /// <summary>
        /// Initialises the first ComboBox in which the user can select a letter of the Alphabet in order to restrict the displayed
        /// items to those beginning with this letter
        /// </summary>
        private void initialiseAlphabeticList()
        {
            this.alphabeticSelector.Items.Add(string.Empty);

            char[] az = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i).ToArray();
            foreach (var c in az)
            {
                this.alphabeticSelector.Items.Add(c);
            }
        }

        /// <summary>
        /// Initialises the second ComboBox in which the user can select, results from which field should be displayed below.
        /// </summary>
        private void initialiseFieldList()
        {
            this.fieldSelector.Items.Add("Patienten");
            this.fieldSelector.Items.Add("Medikamente");
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

        private void alphabeticSelector_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (sender as ComboBox).SelectedIndex = 0;
        }
    }
}
