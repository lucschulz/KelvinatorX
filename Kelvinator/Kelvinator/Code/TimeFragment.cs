using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using KelvinatorX.Strings;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code
{
    public class TimeFragment : BaseFrament
    {
        TimeUnits fromTimeUnits;
        TimeUnits toTimeUnits;


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

        public override void SetFromUnit()
        {
            int rbId = RgFrom.CheckedRadioButtonId;
            RadioButton rb = SV.FindViewById<RadioButton>(rbId);
            string rbText = rb.Text;

            fromTimeUnits = (TimeUnits)SetUnit(rbText);
        }

        public override void SetToUnit()
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

        public override void SetToRadioButtonEvents()
        {
            throw new NotImplementedException();
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
    }
}