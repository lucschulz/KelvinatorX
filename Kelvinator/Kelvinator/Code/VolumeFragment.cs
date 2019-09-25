using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code
{
    public class VolumeFragment : ConversionsBase
    {
        VolumeUnits fromVolumeUnits;
        VolumeUnits toVolumeUnits;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SV = inflater.Inflate(Resource.Layout.fragment_volume, container, false) as ScrollView;

            RgFrom = SV.FindViewById<RadioGroup>(Resource.Id.rg_volume_from);
            RgTo = SV.FindViewById<RadioGroup>(Resource.Id.rg_volume_to);

            base.ConfigureControls();

            return SV;
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void ConfigureEvents()
        {
            // TODO: Move this to abtract class. Method is the same in each derived class.
            SetFromRadioButtonEvents();
            SetToRadioButtonEvents();

            Button btnConvert = SV.FindViewById<Button>(Resource.Id.btn_convert);
            btnConvert.Click += BtnConvert_Click;
        }

        public override void SetFromRadioButtonEvents()
        {
            RadioButton[] rbsFrom = GetFromRadioButtons();
            for (int i = 0; i < rbsFrom.Length; i++)
            {
                rbsFrom[i].Click += FromRadioButton_Click;
            }
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

        public override void SetToRadioButtonEvents()
        {
            throw new NotImplementedException();
        }
    }
}