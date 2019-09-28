using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using KelvinatorX.Code.Conversions;
using KelvinatorX.Strings;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code
{
    public class VolumeFragment : BaseFragment
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

        public override void SetFromUnit()
        {
            int rbId = RgFrom.CheckedRadioButtonId;
            RadioButton rb = SV.FindViewById<RadioButton>(rbId);
            string rbText = rb.Text;

            fromVolumeUnits = (VolumeUnits)SetUnit(rbText);
        }

        public override void SetToUnit()
        {
            int rbId = RgTo.CheckedRadioButtonId;
            RadioButton rb = SV.FindViewById<RadioButton>(rbId);
            string rbText = rb.Text;

            toVolumeUnits = (VolumeUnits)SetUnit(rbText);
        }

        public override object SetUnit(string rbText)
        {
            switch(rbText)
            {
                case Volumes.Liter:
                    return VolumeUnits.Liter;

                case Volumes.CubicCentimeter:
                    return VolumeUnits.CubicCentimeter;

                case Volumes.CubicKilometer:
                    return VolumeUnits.CubicKilometer;

                case Volumes.CubicMeter:
                    return VolumeUnits.CubicMeter;

                case Volumes.CubicMillimeter:
                    return VolumeUnits.CubicMillimeter;

                case Volumes.ImperiaFluidOunce:
                    return VolumeUnits.ImperialFluidOunce;

                case Volumes.ImperialFluidPint:
                    return VolumeUnits.ImperialFluidPint;

                case Volumes.ImperialFluidQuart:
                    return VolumeUnits.ImperialFluidQuart;

                case Volumes.ImperialGallon:
                    return VolumeUnits.ImperialGallon;

                case Volumes.Milliliter:
                    return VolumeUnits.Milliliter;

                case Volumes.USGallon:
                    return VolumeUnits.USGallon;
            }

            throw new Exception("The text value did not match any of the possible units.");
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            var vol = new VolumeConversion(fromVolumeUnits, toVolumeUnits);

            EditText etFrom = SV.FindViewById<EditText>(Resource.Id.et_from_prompt);
            if (etFrom.Text != null)
            {
                double from = Convert.ToDouble(etFrom.Text);
                double toValue = vol.GetConversionResult(from);

                EditText etTo = SV.FindViewById<EditText>(Resource.Id.et_to_prompt);
                etTo.SetText(toValue.ToString(), TextView.BufferType.Normal);
            }
        }
    }
}