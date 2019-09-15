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

        public override RadioButton[] GetFromRadioButtons()
        {
            throw new NotImplementedException();
        }

        public override RadioButton[] GetToRadioButtons()
        {
            throw new NotImplementedException();
        }

        public override void SetFromRadioButtonEvents()
        {
            throw new NotImplementedException();
        }

        public override void SetFromUnit()
        {
            int rbId = RgFrom.CheckedRadioButtonId;
            RadioButton rb = LL.FindViewById<RadioButton>(rbId);
            string rbText = rb.Text;

            switch (rbText)
            {
                case Distances.Meter:
                    fromDistUnits = DistanceUnits.Meter; break;

                case Distances.Kilometer:
                    fromDistUnits = DistanceUnits.Kilometer; break;

                case Distances.Centimeter:
                    fromDistUnits = DistanceUnits.Centimeter; break;

                case Distances.Millimeter:
                    fromDistUnits = DistanceUnits.Millimeter; break;

                case Distances.Nanometer:
                    fromDistUnits = DistanceUnits.Nanometer; break;

                case Distances.Mile:
                    fromDistUnits = DistanceUnits.Mile; break;

                case Distances.Yard:
                    fromDistUnits = DistanceUnits.Yard; break;

                case Distances.Foot:
                    fromDistUnits = DistanceUnits.Foot; break;

                case Distances.Inch:
                    fromDistUnits = DistanceUnits.Inch; break;

                case Distances.AstronomicalUnit:
                    fromDistUnits = DistanceUnits.AstronomicalUnit; break;

                case Distances.LightYear:
                    fromDistUnits = DistanceUnits.LightYear; break;
            }
        }

        public override void SetToRadioButtonEvents()
        {
            throw new NotImplementedException();
        }

        public override void SetToUnit()
        {
            throw new NotImplementedException();
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}