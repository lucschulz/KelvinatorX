using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using KelvinatorX.Strings;
using static KelvinatorX.Code.Enums;
using KelvinatorX.Code.Conversions;

namespace KelvinatorX.Code
{
    public class WeightFragment : BaseFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SV = inflater.Inflate(Resource.Layout.fragment_weight, container, false) as ScrollView;

            RgFrom = SV.FindViewById<RadioGroup>(Resource.Id.rg_from_weights);
            RgTo = SV.FindViewById<RadioGroup>(Resource.Id.rg_to_weights);

            base.ConfigureControls();

            return SV;
        }

        public override object SetUnit(string rbText)
        {
            switch (rbText)
            {
                case Weights.Kilogram:
                    return WeightUnits.Kilogram;

                case Weights.AtomicMassUnit:
                    return WeightUnits.AtomicMassUnit;

                case Weights.Carrat:
                    return WeightUnits.Carrat;

                case Weights.Gram:
                    return WeightUnits.Gram;

                case Weights.LongTon:
                    return WeightUnits.LongTon;

                case Weights.ShortTon:
                    return WeightUnits.ShortTon;

                case Weights.Ounce:
                    return WeightUnits.Pound;

                case Weights.MetricTon:
                    return WeightUnits.MetricTon;

                case Weights.Milligram:
                    return WeightUnits.Milligram;
            }

            throw new Exception("The text value did not match any of the possible units.");
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            var fromUnit = (WeightUnits)base.FromUnitType;
            var toUnit = (WeightUnits)base.ToUnitType;

            var conv = new WeightConversions(fromUnit, toUnit);

            EditText etFrom = SV.FindViewById<EditText>(Resource.Id.et_from_prompt);

            if (etFrom.Text != null)
            {
                double fromValue = Convert.ToDouble(etFrom.Text);
                double toValue = conv.GetConversionResult(fromValue);

                EditText etTo = SV.FindViewById<EditText>(Resource.Id.et_to_prompt);
                etTo.SetText(toValue.ToString(), TextView.BufferType.Normal);
            }
        }
    }
}