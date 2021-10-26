using System;
using System.ComponentModel;
using AwesomeApp;
using AwesomeApp.Elements;
using AwesomeApp.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SampleTabbedPage), typeof(SampleTabbedRenderer))]
namespace AwesomeApp.iOS
{
    public class SampleTabbedRenderer : TabbedRenderer
    {
        protected new SampleTabbedPage Tabbed => (SampleTabbedPage)base.Tabbed;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            StyleTabs();
        }


        private void OnCurrentPageChanged(object sender, EventArgs eventArgs)
        {

        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var oldElement = (SampleTabbedPage)e.OldElement;
                oldElement.CurrentPageChanged -= OnCurrentPageChanged;
                oldElement.PropertyChanged -= ElementOnPropertyChanged;
            }

            if (e.NewElement == null) return;

            //MoreNavigationController.Delegate = new CustomNavigationControllerDelegate(
            //    Tabbed.BackgroundColor.ToUIColor(),
            //    Tabbed.PageTextColor.ToUIColor());

            if (Tabbed.MoreIcon?.File != null)
                MoreNavigationController.TabBarItem = new UITabBarItem("More",
                    new UIImage(Tabbed.MoreIcon.File).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal).ApplyTintColor(Tabbed.TabColor.ToUIColor()),
                    new UIImage(Tabbed.MoreIcon.File).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal).ApplyTintColor(Tabbed.SelectedColor.ToUIColor()));

            // Don't allow swapping of tabs (Maybe support later on when we have time to check for bugs)
            CustomizableViewControllers = null;
            TabBar.SelectedImageTintColor = Tabbed.SelectedColor.ToUIColor();

            Tabbed.CurrentPageChanged += OnCurrentPageChanged;
            Tabbed.PropertyChanged += ElementOnPropertyChanged;
        }

        private void ElementOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == SampleTabbedPage.TabColorProperty.PropertyName
                || args.PropertyName == SampleTabbedPage.SelectedColorProperty.PropertyName
                || args.PropertyName == SampleTabbedPage.MoreIconProperty.PropertyName)
                StyleTabs();
        }

        private void StyleTabs()
        {
            foreach (var t in TabBar.Items)
                SetupTab(t);
        }

        private void SetupTab(UITabBarItem tab)
        {
            if (tab.Image != null)
            {
                // The "More" UITabBarItem is distinguished by an empty title
                if (string.IsNullOrEmpty(tab.Title))
                {
                    if (Tabbed.MoreIcon?.File != null)
                        tab.Image = new UIImage(Tabbed.MoreIcon.File).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                }
                else
                {
                    tab.Image = tab.Image.ApplyTintColor(Tabbed.TabColor.ToUIColor());
                }
            }
            var normalAtributes = new UITextAttributes();
            normalAtributes.TextColor = Tabbed.TabColor.ToUIColor();
            var selectedAtributes = new UITextAttributes();
            selectedAtributes.TextColor = Tabbed.SelectedColor.ToUIColor();
            // Set Tab Text Color
            tab.SetTitleTextAttributes(normalAtributes, UIControlState.Normal);
            tab.SetTitleTextAttributes(selectedAtributes, UIControlState.Selected);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            if (MoreNavigationController == null) return;

            // Style the "More" tab page on iOS a little bit.
            MoreNavigationController.NavigationBarHidden = true;
            var vc = MoreNavigationController.TopViewController;
            var tv = vc.View as UITableView;
            if (tv == null) return;

            //tv.FixCellMargins();
            tv.TableFooterView = new UIView();
            tv.TintColor = Tabbed.TabColor.ToUIColor();
            tv.BackgroundColor = Tabbed.BackgroundColor.ToUIColor();
        }
    }

    public class CustomNavigationControllerDelegate : UINavigationControllerDelegate
    {
        private UIColor _backgroundColor;
        private UIColor _textColor;

        public CustomNavigationControllerDelegate(UIColor backgroundColor, UIColor textColor)
        {
            _backgroundColor = backgroundColor;
            _textColor = textColor;
        }

        public override void WillShowViewController(UINavigationController navigationController,
            UIViewController viewController, bool animated)
        {
            // This will style the More page cells
            var tableView = viewController.View as UITableView;
            if (tableView != null)
            {
                tableView.SeparatorInset = UIEdgeInsets.Zero;
                foreach (var cell in tableView.VisibleCells)
                {
                    cell.BackgroundColor = _backgroundColor;
                    cell.TextLabel.TextColor = _textColor;
                    cell.Accessory = UITableViewCellAccessory.None;
                    cell.SeparatorInset = UIEdgeInsets.Zero;
                }
            }
        }
    }
}