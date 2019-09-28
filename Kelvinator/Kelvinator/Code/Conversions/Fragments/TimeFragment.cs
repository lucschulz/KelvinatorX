using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using KelvinatorX.Code.Conversions;
using KelvinatorX.Strings;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code
{
    public class TimeFragment : BaseFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SV = inflater.Inflate(Resource.Layout.fragment_time, container, false) as ScrollView;

            RgFrom = SV.FindViewById<RadioGroup>(Resource.Id.rg_time_from);
            RgTo = SV.FindViewById<RadioGroup>(Resource.Id.rg_time_to);

            ConfigureControls();

            return SV;
        }

        public override object SetUnit(string rbText)
        {
            switch(rbText)
            {
                case Times.Day:
                    return TimeUnits.Day;

                case Times.Picosecond:
                    return TimeUnits.Picosecond;

                case Times.Nanosecond:
                    return TimeUnits.Nanosecond;

                case Times.Microsecond:
                    return TimeUnits.Microsecond;

                case Times.Millisecond:
                    return TimeUnits.Millisecond;

                case Times.Second:
                    return TimeUnits.Second;

                case Times.Minute:
                    return TimeUnits.Minute;

                case Times.Hour:
                    return TimeUnits.Hour;

                case Times.Week:
                    return TimeUnits.Week;

                case Times.Month:
                    return TimeUnits.Month;

                case Times.Year:
                    return TimeUnits.Year;
            }

            throw new Exception("The text value did not match any of the possible units.");
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            var fromUnit = (TimeUnits)base.FromUnitType;
            var toUnit = (TimeUnits)base.ToUnitType;

            var conv = new TimeConversions(fromUnit, toUnit);

            EditText etFrom = SV.FindViewById<EditText>(Resource.Id.et_from_prompt);
            if (etFrom.Text != null)
            {
                double from = Convert.ToDouble(etFrom.Text);
                double toValue = conv.GetConversionResult(from);

                EditText etTo = SV.FindViewById<EditText>(Resource.Id.et_to_prompt);
                etTo.SetText(toValue.ToString(), TextView.BufferType.Normal);
            }
        }
    }
}