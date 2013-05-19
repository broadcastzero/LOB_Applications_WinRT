using System;
using System.Collections.Generic;
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
    public sealed class OrdinationMask : Control
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
    }
}
