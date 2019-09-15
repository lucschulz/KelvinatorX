using Android.Support.V4.App;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Android.InputMethodServices;
using Android.Content.PM;

namespace Kelvinator.Code
{
    public class AboutFragment : Fragment
    {
        LinearLayout ll;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ll = inflater.Inflate(Resource.Layout.fragment_about, container, false) as LinearLayout;

            InputMethodManager imm = Context.GetSystemService(InputMethodService.InputMethodService) as InputMethodManager;
            imm.HideSoftInputFromWindow(ll.WindowToken, HideSoftInputFlags.NotAlways);

            SetVersionNumber();

            return ll;
        }

        private void SetVersionNumber()
        {
            PackageManager manager = Context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(Context.PackageName, 0);

            TextView tvVersion = ll.FindViewById<TextView>(Resource.Id.tvVersionNumber);
            tvVersion.SetText(info.VersionName, TextView.BufferType.Normal);
        }
    }
}