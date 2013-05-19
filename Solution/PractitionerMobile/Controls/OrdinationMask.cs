using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at
// http://go.microsoft.com/fwlink/?LinkId=234235
namespace PractitionerMobile.Controls
{
	/// <summary>
	/// This class contains Practitioner Mobiles' custom control -
	/// a control, in which data of an ordination can be entered.
	/// </summary>
	[TemplatePart(Name = "Ok", Type = typeof(Button))]
	[TemplatePart(Name = "Cancel", Type = typeof(Button))]
	[TemplatePart(Name = "SocialInsurance", Type = typeof(ComboBox))]
	[TemplatePart(Name = "DurationMinutes", Type = typeof(TextBox))]
	[TemplatePart(Name = "Diagnosis", Type = typeof(TextBox))]
	public sealed class OrdinationMask : Control
	{
		public OrdinationMask()
		{
			this.DefaultStyleKey = typeof(OrdinationMask);            
		}

		#region Public properties
		public string SocialInsurance
		{
			get;
			private set;
		}

		public int DurationMinutes
		{
			get;
			private set;
		}

		public string Diagnosis
		{
			get;
			private set;
		}
		#endregion

		#region Image
		public ImageSource ImagePath
		{
			get { return (ImageSource)GetValue(ImagePathProperty); }
			set { SetValue(ImagePathProperty, value); }
		}

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
		public event TappedEventHandler OkButtonHit;
		public event TappedEventHandler CancelButtonHit;
	
		/// <summary>
		/// Saves TextBox values to properties and calls custom OK-event.
		/// </summary>
		private void okButton_Tapped(object sender, TappedRoutedEventArgs e)
		{
			if(OkButtonHit != null)
			{
				var selectedListBoxItem = ((ComboBox)GetTemplateChild("SocialInsurance")).SelectedItem;
				if (selectedListBoxItem == null)
					return;

				this.SocialInsurance = selectedListBoxItem.ToString();
				this.Diagnosis = ((TextBox)GetTemplateChild("Diagnosis")).Text;

				string duration = ((TextBox)GetTemplateChild("DurationMinutes")).Text;
				int minutes;
				bool couldParse = int.TryParse(duration, out minutes);
				this.DurationMinutes = couldParse && minutes >= 0 ? minutes : 0;

				OkButtonHit(this, null);
			}

			this.ClearFields();
		}

		/// <summary>
		/// Calls custom cancel event and clears fields.
		/// </summary>
		private void cancelButton_Tapped(object sender, TappedRoutedEventArgs e)
		{
			if(CancelButtonHit != null)
			{
				CancelButtonHit(this, null);
			}

			this.ClearFields();
		}
		#endregion

		/// <summary>
		/// Sets events to OK and cancel button.
		/// </summary>
		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			Button okButton = (Button)GetTemplateChild("Ok");
			Button cancelButton= (Button)GetTemplateChild("Cancel");

			okButton.Tapped += okButton_Tapped;
			cancelButton.Tapped += cancelButton_Tapped;
		}

		/// <summary>
		/// Clears all fields of the control.
		/// </summary>
		private void ClearFields()
		{
			ComboBox socialInsurance = (ComboBox)GetTemplateChild("SocialInsurance");
			TextBox duration = (TextBox)GetTemplateChild("DurationMinutes");
			TextBox diagnosis = (TextBox)GetTemplateChild("Diagnosis");

			socialInsurance.SelectedIndex = -1;
			duration.Text = string.Empty;
			diagnosis.Text = string.Empty;
		}
	}
}
