using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Kelvinator.Strings;
using static Kelvinator.Code.Enums;

namespace Kelvinator.Code
{
    public class DistanceFragment : ConversionsBase
    {
        DistanceUnits fromDistUnits;
        DistanceUnits toDistUnits;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            LL = inflater.Inflate(Resource.Layout.fragment_distance, container, false) as LinearLayout;
            ConfigureControls();
            return LL;
        }

        public override void ConfigureControls()
        {
            RgFrom = LL.FindViewById<RadioGroup>(Resource.Id.rg_temp_from);
            RgTo = LL.FindViewById<RadioGroup>(Resource.Id.rg_temp_to);

            SetFromUnit();
            SetToUnit();
            ConfigureEvents();
        }

        public override void ConfigureEvents()
        {
            throw new NotImplementedException();
        }

        public override void SetFromUnit()
        {
            int rbId = RgFrom.CheckedRadioButtonId;
            RadioButton rb = LL.FindViewById<RadioButton>(rbId);
            string rbText = rb.Text;

            fromDistUnits = SetUnit(rbText);
        }

        public override void SetToUnit()
        {
            int rbId = RgTo.CheckedRadioButtonId;
            RadioButton rb = LL.FindViewById<RadioButton>(rbId);
            string rbText = rb.Text;

            toDistUnits = SetUnit(rbText);
        }

        public override DistanceUnits SetUnit(string rbText)
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

        public override void SetToRadioButtonEvents()
        {
            throw new NotImplementedException();
        }

        public override void SetFromRadioButtonEvents()
        {
            throw new NotImplementedException();
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}