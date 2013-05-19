using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PractitionerMobile.Controls
{
    /// <summary>
    /// The custom control which is implemented for demonstration purposes only and not used in solution.
    /// </summary>
    public class ButtonBase : ContentControl
    {
        public bool IsPressed
        {
            get { return (bool)GetValue(IsPressedProperty); }
            set { SetValue(IsPressedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPressedProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPressedProperty = 
            DependencyProperty.Register("IsPressed", typeof(bool), typeof(ButtonBase), new PropertyMetadata(false, OnIsPressedChanged));

        private static void OnIsPressedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("button pressed: " + e.NewValue);
        }
    }
}
