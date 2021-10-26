using System;
using Xamarin.Forms;

namespace AwesomeApp.ControlPages
{
    public class ElementListing
    {
        public ElementListing(string title, string subtitle, Func<Page> getPage)
        {
            Title = title;
            Subtitle = subtitle;
            GetPage = getPage;
        }


        public string Title { get; set; }
        public string Subtitle { get; set; }
        public Func<Page> GetPage { get; set; }
    }
}
