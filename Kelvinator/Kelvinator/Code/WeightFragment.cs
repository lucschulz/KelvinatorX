using Android.Support.V4.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace KelvinatorX.Code
{
    public class WeightFragment : ConversionsBase
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            LL = inflater.Inflate(Resource.Layout.fragment_weight, container, false) as LinearLayout;
            return LL;
        }
        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void ConfigureControls()
        {
            throw new NotImplementedException();
        }

        public override void ConfigureEvents()
        {
            throw new NotImplementedException();
        }

        public override void SetFromRadioButtonEvents()
        {
            throw new NotImplementedException();
        }

        public override void SetFromUnit()
        {
            throw new NotImplementedException();
        }

        public override void SetToRadioButtonEvents()
        {
            throw new NotImplementedException();
        }

        public override void SetToUnit()
        {
            throw new NotImplementedException();
        }

        public override Enums.DistanceUnits SetUnit(string rbText)
        {
            throw new NotImplementedException();
        }
    }
}