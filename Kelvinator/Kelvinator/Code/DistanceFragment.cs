using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Kelvinator.Code.Conversions;
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
            RgFrom = LL.FindViewById<RadioGroup>(Resource.Id.rg_distances_from);
            RgTo = LL.FindViewById<RadioGroup>(Resource.Id.rg_distances_to);

            SetFromUnit();
            SetToUnit();
            ConfigureEvents();
        }

        public override void ConfigureEvents()
        {
            SetFromRadioButtonEvents();
            SetToRadioButtonEvents();

            Button btnConvert = LL.FindViewById<Button>(Resource.Id.btn_convert);
            btnConvert.Click += BtnConvert_Click;
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

        public override void SetFromRadioButtonEvents()
        {
            RadioButton[] rbsFrom = GetFromRadioButtons();
            for (int i = 0; i < rbsFrom.Length; i++)
            {
                rbsFrom[i].Click += DistanceFragment_Click1;
            }
        }

        private void DistanceFragment_Click1(object sender, EventArgs e)
        {
            SetFromUnit();
        }

        public override void SetToRadioButtonEvents()
        {
            RadioButton[] rbsTo = GetToRadioButtons();
            for (int i = 0; i < rbsTo.Length; i++)
            {
                rbsTo[i].Click += DistanceFragment_Click;
            }
        }

        private void DistanceFragment_Click(object sender, EventArgs e)
        {
            SetToUnit();
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            var conv = new DistanceConversions(fromDistUnits, toDistUnits);

            EditText etFromDist = LL.FindViewById<EditText>(Resource.Id.et_from_prompt);
            if (etFromDist.Text != null)
            {
                double from = Convert.ToDouble(etFromDist.Text);
                double toValue = conv.GetConversiondResult(from);

                EditText etTo = LL.FindViewById<EditText>(Resource.Id.et_to_prompt);
                etTo.SetText(toValue.ToString(), TextView.BufferType.Normal);
            }
        }
    }
}