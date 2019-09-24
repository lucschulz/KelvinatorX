using System;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace KelvinatorX.Code
{
    public class VolumeFragment : ConversionsBase
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SV = inflater.Inflate(Resource.Layout.fragment_volume, container, false) as ScrollView;
            return SV;
        }
        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void ConfigureControls()
        {
            throw new NotImplementedException();
        }

        public void ConfigureEvents()
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

        public override object SetUnit(string rbText)
        {
            throw new NotImplementedException();
        }
    }
}