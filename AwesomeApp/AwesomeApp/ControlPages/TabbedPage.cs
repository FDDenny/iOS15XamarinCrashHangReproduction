using System;
using Xamarin.Forms;
using AwesomeApp.Elements;
using System.Diagnostics;

namespace AwesomeApp.ControlPages
{
    public class TabbedPagePage : SampleTabbedPage
    {
        private SampleContentPage page1;
        private SampleContentPage page2;
        private SampleContentPage page3;
        private SampleContentPage page4;
        private SampleContentPage page5;
        private SampleContentPage page6;
        private SampleContentPage page7;
        private SampleContentPage page8;
        private SampleContentPage page9;

        public TabbedPagePage()
        {
            SelectedColor = Color.Green;
            TabColor = Color.Blue;

            var dummyButton = new Button { Text = "Push dummy", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            dummyButton.Clicked += DummyButtonOnClicked;
            page1 = new SampleContentPage { Title = "One", Content = dummyButton};
            page2 = new SampleContentPage { Title = "Two"};
            page3 = new SampleContentPage { Title = "Three"};
            page4 = new SampleContentPage { Title = "Four"};
            page5 = new SampleContentPage { Title = "Five"};
            page6 = new SampleContentPage { Title = "Six"};
            page7 = new SampleContentPage { Title = "Seven"};
            page8 = new SampleContentPage { Title = "Eight"};
            page9 = new SampleContentPage { Title = "Nine"};

            Children.Add(page1);
            Children.Add(page2);
            Children.Add(page3);
            Children.Add(page4);
            Children.Add(page5);
            Children.Add(page6);
            Children.Add(page7);
            Children.Add(page8);
            Children.Add(page9);
        }

        private bool _pushing;
        private async void DummyButtonOnClicked(object sender, EventArgs eventArgs)
        {
            if (_pushing) return;
            _pushing = true;
            try
            {
                await Navigation.PushAsync(new ContentPage { BackgroundColor = Color.Red }, true);
            }
            catch { }
            _pushing = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("TabbedPage Appearing");
            page1.Appearing += ChildPageOnAppearing;
            page2.Appearing += ChildPageOnAppearing;
            page3.Appearing += ChildPageOnAppearing;
            page1.Disappearing += ChildPageOnDisappearing;
            page2.Disappearing += ChildPageOnDisappearing;
            page3.Disappearing += ChildPageOnDisappearing;
        }

        private void ChildPageOnAppearing(object sender, EventArgs eventArgs)
        {
            var page = (Page)sender;
            //DisplayAlert("Page " + page.Title, "Appearing", "Okay");
            Debug.WriteLine("Page " + page.Title + " Appearing");
        }

        private void ChildPageOnDisappearing(object sender, EventArgs eventArgs)
        {
            var page = (Page)sender;
            //DisplayAlert("Page " + page.Title, "Disappearing", "Okay");
            Debug.WriteLine("Page " + page.Title + " Disappearing");
        }

        protected override void OnDisappearing()
        {
            page1.Appearing -= ChildPageOnAppearing;
            page2.Appearing -= ChildPageOnAppearing;
            page3.Appearing -= ChildPageOnAppearing;
            page1.Disappearing -= ChildPageOnDisappearing;
            page2.Disappearing -= ChildPageOnDisappearing;
            page3.Disappearing -= ChildPageOnDisappearing;
            Debug.WriteLine("TabbedPage Disappearing");
            base.OnDisappearing();
        }
    }
}
