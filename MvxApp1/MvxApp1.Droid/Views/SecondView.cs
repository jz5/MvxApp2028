using Android.App;
using Android.OS;

namespace MvxApp1.Droid.Views
{
    [Activity]
    public class SecondView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.SecondView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
        }
    }
}
