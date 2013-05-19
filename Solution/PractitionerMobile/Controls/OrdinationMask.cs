﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace PractitionerMobile.Controls
{
    /// <summary>
    /// This class contains Practitioner Mobiles' custom control - a control, in which data of an ordination can be entered.
    /// </summary>
    [TemplatePart(Name = "OkButton", Type = typeof(Button))]
    [TemplatePart(Name = "CancelButton", Type = typeof(Button))]
    public sealed class OrdinationMask : ContentControl
    {
        public OrdinationMask()
        {
            this.DefaultStyleKey = typeof(OrdinationMask);            
        }

        #region Image
        public ImageSource ImagePath
        {
            get { return (ImageSource)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagePathProperty = 
            DependencyProperty.Register("ImagePath", typeof(ImageSource), typeof(OrdinationMask), new PropertyMetadata(null));
        #endregion

        #region Social Insurances
        private static List<string> _defaultSocialInsurances = new List<string>() { "NoeGkk", "Wgkk", "BVA" };

        public static readonly DependencyProperty SocialInsurancesProperty =
              DependencyProperty.Register("SocialInsurances",
              typeof(IEnumerable<string>),
              typeof(OrdinationMask),
              new PropertyMetadata(_defaultSocialInsurances));

        public IEnumerable<string> SocialInsurances
        {
            get { return (IEnumerable<string>) GetValue(SocialInsurancesProperty); }
            set { SetValue(SocialInsurancesProperty, value); }
        }
        #endregion

        #region Button logic
        public event TappedEventHandler OnOkButtonHit;
        public event TappedEventHandler OnCancelButtonHit;
	
        /// <summary>
        /// Calls custom OK event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
	    private void okButton_Tapped(object sender, TappedRoutedEventArgs e)
	    {
            if(OnOkButtonHit != null)
            {
	            OnOkButtonHit(this, null);            
            }
	    }

        /// <summary>
        /// Calls custom event and clears fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(OnCancelButtonHit != null)
            {
                OnCancelButtonHit(this, null);
            }

            this.ClearFields();
        }
        #endregion

        /// <summary>
        /// Sets events to buttons.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Button okButton = (Button)GetTemplateChild("OkButton");
            Button cancelButton= (Button)GetTemplateChild("CancelButton");

            okButton.Tapped += okButton_Tapped;
            cancelButton.Tapped += cancelButton_Tapped;
        }

        /// <summary>
        /// Clears all fields of the control.
        /// </summary>
        private void ClearFields()
        {
            ComboBox socialInsurance = (ComboBox)GetTemplateChild("SocialInsurance");
            TextBox duration = (TextBox)GetTemplateChild("Duration");
            TextBox diagnosis = (TextBox)GetTemplateChild("Diagnosis");

            socialInsurance.SelectedIndex = -1;
            duration.Text = string.Empty;
            diagnosis.Text = string.Empty;
        }
    }
}
