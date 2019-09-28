using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using KelvinatorX.Code.Conversions;
using KelvinatorX.Strings;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code
{
    public class DistanceFragment : BaseFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SV = inflater.Inflate(Resource.Layout.fragment_distance, container, false) as ScrollView;

            RgFrom = SV.FindViewById<RadioGroup>(Resource.Id.rg_distances_from);
            RgTo = SV.FindViewById<RadioGroup>(Resource.Id.rg_distances_to);

            base.ConfigureControls();

            return SV;
        }

        public override object SetUnit(string rbText)
        {
            switch (rbText)
            {
                case Distances.Meter:
                    return DistanceUnits.Meter;

                case Distances.Kilometer:
                    return DistanceUnits.Kilometer;

                case Distances.Centimeter:
                    return DistanceUnits.Centimeter;

                case Distances.Millimeter:
                    return DistanceUnits.Millimeter;

                case Distances.Nanometer:
                    return DistanceUnits.Nanometer;

                case Distances.Mile:
                    return DistanceUnits.Mile;

                case Distances.Yard:
                    return DistanceUnits.Yard;

                case Distances.Foot:
                    return DistanceUnits.Foot;

                case Distances.Inch:
                    return DistanceUnits.Inch;

                case Distances.AstronomicalUnit:
                    return DistanceUnits.AstronomicalUnit;

                case Distances.LightYear:
                    return DistanceUnits.LightYear;
            }

            throw new Exception("The text value did not match any of the possible units.");
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            var fromUnit = (DistanceUnits)base.FromUnitType;
            var toUnit = (DistanceUnits)base.ToUnitType;

            var conv = new DistanceConversions(fromUnit, toUnit);

            EditText etFromDist = SV.FindViewById<EditText>(Resource.Id.et_from_prompt);
            if (etFromDist.Text != null)
            {
                double fromValue = Convert.ToDouble(etFromDist.Text);
                double toValue = conv.GetConversionResult(fromValue);

                EditText etTo = SV.FindViewById<EditText>(Resource.Id.et_to_prompt);
                etTo.SetText(toValue.ToString(), TextView.BufferType.Normal);
            }
        }
    }
}