using System;
using Windows.UI.Xaml.Controls;

namespace PractitionerMobile
{
    sealed class SearchResult
    {
        public Uri Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
    }
}
