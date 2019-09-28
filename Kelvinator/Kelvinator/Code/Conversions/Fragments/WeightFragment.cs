using Android.Support.V4.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace KelvinatorX.Code
{
    public class WeightFragment : BaseFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SV = inflater.Inflate(Resource.Layout.fragment_weight, container, false) as ScrollView;

            RgFrom = SV.FindViewById<RadioGroup>(Resource.Id.rg_from_weights);
            RgTo = SV.FindViewById<RadioGroup>(Resource.Id.rg_to_weights);

            base.ConfigureControls();

            return SV;
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void SetFromUnit()
        {
            throw new NotImplementedException();
        }

        public override void SetToUnit()
        {
            throw new NotImplementedException();
        }

        public override object SetUnit(string rbText)
        {
            throw new NotImplementedException();
        }
    }
}