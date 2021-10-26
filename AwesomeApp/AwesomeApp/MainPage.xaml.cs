using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeApp.Elements;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace AwesomeApp
{
    public partial class MainPage: SampleContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        int count = 0;
        private async void Button_Clicked(object sender, EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";


        }
    }
}
