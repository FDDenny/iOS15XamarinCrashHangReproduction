using System;
using Xamarin.Forms;
using AwesomeApp.Elements;
using System.Collections.Generic;
using System.Linq;

namespace AwesomeApp.ControlPages
{
    public class ElementListPage : ContentPage
    {

        private readonly List<ElementListing> _elements = new List<ElementListing>
        {
            new ElementListing(nameof(MainPage), "This is Default Page", () => new MainPage()),
            new ElementListing(nameof(SampleTabbedPage), "Testing appearing stuff", () => new TabbedPagePage()),
            new ElementListing(nameof(SampleTabbedPage), "Second tab page to go back and forth", () => new TabbedPagePage()),

        };

        public ElementListPage()
        {
            Title = "Elements";

            var listView = new ListView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                ItemTemplate = new DataTemplate(() => new ElementCell()),
                ItemsSource = _elements,
            };

            listView.ItemSelected += ListViewOnItemSelected;

            var stack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {listView }
            };

            Content = stack;

        }

        public Page GetDefaultPage()
        {
            return _elements.First().GetPage();
        }

        private bool _selecting;
        private async void ListViewOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            if (_selecting) return;
            _selecting = true;

            var listing = selectedItemChangedEventArgs.SelectedItem as ElementListing;
            if (listing == null)
            {
                _selecting = false;
                return;
            }

            var page = listing.GetPage();

            // Put new page under the current page and pop the old page
            var current = (MasterDetailPage)Application.Current.MainPage;
            var detail = current.Detail;
            detail.Navigation.InsertPageBefore(page, detail.Navigation.NavigationStack[0]);
            await detail.Navigation.PopAsync(true);


            // Toggle the title to make sure it shows up correctly
            var title = current.Master.Title;
            current.Master.Title = " ";
            current.Master.Title = title;

            // Hide the menu
            if (Device.RuntimePlatform != Device.UWP)
                current.IsPresented = false;

            var listView = sender as ListView;
            if (listView == null)
            {
                _selecting = false;
                return;
            }

            listView.SelectedItem = null;
            _selecting = false;
        }
    }
}
