using System;
using Xamarin.Forms;
namespace AwesomeApp.ControlPages
{
    public class ElementCell : ImageCell
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var listing = BindingContext as ElementListing;

            if (listing == null)
            {
                Text = null;
                Detail = null;
            }
            else
            {
                Text = listing.Title;
                Detail = listing.Subtitle;
            }
        }
    }
}
