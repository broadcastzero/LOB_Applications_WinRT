using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace PractitionerMobile.HelperClasses
{
    public class MedicamentInitialiser
    {
        private static string[] _medicamentNames = new string[]
        {
            "ABC Pflaster (sensitiv)",
            "Diclabeta",
            "Diclac Schmerzgel",
            "Dolormin Mobil Gel",
            "Hepa",
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
        /// Definitions from http://www.apotheken-umschau.de, access at May 14th, 2013
        /// </summary>
        private static string[] _medicamentDescriptions = new string[]
        {
            "Hansaplast med ABC wärme Creme enthält den Wirkstoff Capsaicin, ein Arzneimittel aus der Gruppe der sogenannten durchblutungssteigernden Rheumamittel zur Wärme-Reiz-Therapie.",
            "Diclabeta Schmerzgel enthält den Wirkstoff Diclofenac, ein Arzneimittel aus der Gruppe der sogenannten nicht-steroidalen Antiphlogistika/Analgetika (Entzündungshemmer/Schmerzmittel). Beim Menschen reduziert Diclofenac entzündlich bedingte Schmerzen und Schwellungen.",
            "Diclac 25 Magensaftresistente Tabletten enthält den Wirkstoff Diclofenac, ein schmerzstillendes und entzündungshemmendes Arzneimittel aus der Gruppe der sogenannten nicht-steroidalen Antiphlogistika/Analgetika (Entzündungshemmer/Schmerzmittel).",
            "Dolormin instant schnell löslich Granulat enthält Ibuprofen, ein entzündungshemmendes und schmerzstillendes Arzneimittel aus der Gruppe der sogenannten nicht-steroidalen Antiphlogistika/Analgetika. Es wird als Ibuprofen oder in Salzform als Ibuprofen-DL-lysinat angewendet.",
            "Hepa Merz Granulat 3000 enthält den Wirkstoff Ornithinaspartat, ein Arzneimittel aus der Gruppe der sogenannten Lebertherapeutika. Ornithinaspartat stimuliert die Ammoniakentgiftung durch Steigerung der Harnstoffsynthese in der Leber.",
            "Heparin ratio 60000 Salbe enthält den Wirkstoff Heparin (aus Schweinedarmmukosa), ein Arzneimittel aus der Gruppe der sogenannten Vasoprotektoren und gerinnungshemmenden Arzneimittel. Heparin wirkt unterstützend bei der lokalen Behandlung von verletztem Gewebe und Blutgefäßen mit Entzündungs- und Schwellungszuständen.",
            "Ibutop 200 mg Schmerztabletten Filmtabletten enthält den Wirkstoff Ibuprofen, ein Arzneimittel aus der Gruppe der sogenannten nichtsteriodalen Antiphlogistika/Analgetika (Entzündungshemmer/Schmerzmittel). Ibuprofen reduziert entzündlich bedingte Schmerzen, Schwellungen und Fieber.",
            "lorem",
            "lorem",
            "lorem",
            "lorem",
            "lorem",
            "lorem",
            "lorem",
            "lorem",
            "lorem",
            "lorem",
            "lorem",
            "lorem",
            "lorem",
            "lorem"
        };

        private static string[] _pathToImage = new string[]
        {
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
            "ms-appx:///Assets/Logo.png",
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
        /// Creates a collection of medicaments and returns it.
        /// </summary>
        /// <returns></returns>
        internal static ObservableCollection<Medicament> Create()
        {
            ObservableCollection<Medicament> medicaments = new ObservableCollection<Medicament>();

            // Create names
            foreach (string name in _medicamentNames)
            {
                medicaments.Add(new Medicament(name));
            }

            // Create descriptions
            for (int i=0; i < _medicamentDescriptions.Count(); i++)
            {
                medicaments[i].Description = _medicamentDescriptions[i];
            }

            // Create image
            for (int i=0; i < _pathToImage.Count(); i++)
            {
                medicaments[i].Picture = new BitmapImage(new Uri(_pathToImage[i]));
            }

            return medicaments;
        }

    }
}
