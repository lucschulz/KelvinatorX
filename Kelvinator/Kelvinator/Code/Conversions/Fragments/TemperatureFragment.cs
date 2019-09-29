using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using KelvinatorX.Code.Conversions;
using KelvinatorX.Strings;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code
{
    public class TemperatureFragment : BaseFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SV = inflater.Inflate(Resource.Layout.fragment_temperature, container, false) as ScrollView;

            RgFrom = SV.FindViewById<RadioGroup>(Resource.Id.rg_temp_from);
            RgTo = SV.FindViewById<RadioGroup>(Resource.Id.rg_temp_to);

            ConfigureControls();

            return SV;
        }

        public override object SetUnit(string rbText)
        {
            switch (rbText)
            {
                case Temperatures.Celsius:
                    return TemperatureUnits.Celsius;

                case Temperatures.Fahrenheit:
                    return TemperatureUnits.Fahrentheit;

                case Temperatures.Kelvin:
                    return TemperatureUnits.Kelvin;
            }

            throw new Exception("The text value did not match any of the possible units.");
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            var fromUnit = (TemperatureUnits)base.FromUnitType;
            var toUnit = (TemperatureUnits)base.ToUnitType;

            var conv = new TemperatureConversions(fromUnit, toUnit);

            EditText etFrom = SV.FindViewById<EditText>(Resource.Id.et_from_prompt);
            if (etFrom.Text != null)
            {
                double fromValue = Convert.ToDouble(etFrom.Text);
                double toValue = 0;

                if (fromValue != 0)
                {
                    toValue = conv.GetConversionResult(fromValue);
                }
                else
                {
                    toValue = GetToValueForZeroFromValue(fromUnit, toUnit);
                }


                EditText etTo = SV.FindViewById<EditText>(Resource.Id.et_to_prompt);
                etTo.SetText(toValue.ToString(), TextView.BufferType.Normal);
            }
        }

        private double GetToValueForZeroFromValue(TemperatureUnits fromUnit, TemperatureUnits toUnit)
        {
            switch (fromUnit)
            {
                case TemperatureUnits.Celsius:
                    if (toUnit == TemperatureUnits.Fahrentheit)
                    {
                        return -32;
                    }
                    else
                    {
                        return -273.15;
                    }

                case TemperatureUnits.Kelvin:
                    if (toUnit == TemperatureUnits.Fahrentheit)
                    {
                        return -459.67;
                    }
                    else
                    {
                        return -273.15;
                    }

                case TemperatureUnits.Fahrentheit:
                    if (toUnit == TemperatureUnits.Celsius)
                    {
                        return -32;
                    }
                    else
                    {
                        return -17.7778;
                    }
            }

            throw new Exception("The 'FROM' and 'TO' units could not be properly determined for an input value of 0.");
        }
    }
}