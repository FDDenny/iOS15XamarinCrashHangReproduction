using AwesomeApp.Elements;
using AwesomeApp.ControlPages;
using Xamarin.Forms;

namespace AwesomeApp
{
    public partial class App : Application
    {
        private SampleMasterDetailPage _navigation;

        public App()
        {
            InitializeComponent();

            var List = new ElementListPage();

            _navigation = new SampleMasterDetailPage()
            {
                Master = List,
                Detail = new SampleNavigationPage(List.GetDefaultPage()) { BarTextColor = Color.Blue }
            };

            MainPage = _navigation;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
