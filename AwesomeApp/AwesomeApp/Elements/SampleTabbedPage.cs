using System;
using Xamarin.Forms;

namespace AwesomeApp.Elements
{
    public class SampleTabbedPage : TabbedPage
    {
        public SampleTabbedPage() : base()
        {
            Title = "Tabbed Page";
        }

        public static readonly BindableProperty SelectedColorProperty =
    BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(SampleTabbedPage), Color.White);

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly BindableProperty TabColorProperty =
            BindableProperty.Create(nameof(TabColor), typeof(Color), typeof(SampleTabbedPage), Color.Black);

        public Color TabColor
        {
            get { return (Color)GetValue(TabColorProperty); }
            set { SetValue(TabColorProperty, value); }
        }


        public static readonly BindableProperty PageTextColorProperty =
            BindableProperty.Create(nameof(PageTextColor), typeof(Color), typeof(SampleTabbedPage), Color.Black);

        public Color PageTextColor
        {
            get { return (Color)GetValue(PageTextColorProperty); }
            set { SetValue(PageTextColorProperty, value); }
        }

        public static readonly BindableProperty MoreIconProperty =
            BindableProperty.Create(nameof(MoreIcon), typeof(FileImageSource), typeof(SampleTabbedPage));

        public FileImageSource MoreIcon
        {
            get { return (FileImageSource)GetValue(MoreIconProperty); }
            set { SetValue(MoreIconProperty, value); }
        }

        public void OnPageAppearing()
        {
            OnAppearing();
        }

        public void OnPageDisappearing()
        {
            OnDisappearing();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // subscribe to page change to update title on windows
            //if (Device.OS == TargetPlatform.Windows)
            //    CurrentPageChanged += OnCurrentPageChanged;
        }

        protected override void OnDisappearing()
        {
            // unsubscribe from page change on windows
            //if (Device.OS == TargetPlatform.Windows)
            //    CurrentPageChanged -= OnCurrentPageChanged;

            base.OnDisappearing();
        }
    }
}
