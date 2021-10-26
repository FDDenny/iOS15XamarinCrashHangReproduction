using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace AwesomeApp.Elements
{
    public class SampleContentPage : ContentPage
    {
        public SampleContentPage()
        {
            Title = "Content Page"; // TFS #26872 - Need to set the Title property to a single space by default to prevent the hamburger menu from disappearing in the Windows version of the app
        }

        public void OnPageAppearing()
        {
            OnAppearing();
        }

        public void OnPageDisappearing()
        {
            OnDisappearing();
        }

        public void RemoveBindings()
        {
            this.UnapplyBindings();
        }
    }
}
