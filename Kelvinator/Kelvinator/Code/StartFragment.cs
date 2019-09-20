using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace KelvinatorX.Code
{
    public class StartFragment : Fragment
    {
        LinearLayout ll;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ll = inflater.Inflate(Resource.Layout.fragment_start, container, false) as LinearLayout;
            return ll;
        }
    }
}