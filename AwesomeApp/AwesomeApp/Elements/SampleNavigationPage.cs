using System;
using Xamarin.Forms;

namespace AwesomeApp.Elements
{
    public class SampleNavigationPage : NavigationPage
    {
        public SampleNavigationPage() : base()
        {
            Title = "Navigation Page";
        }

        public SampleNavigationPage(Page root) : base(root)
        {
            Title = "Navigation Page";
        }
    }
}
