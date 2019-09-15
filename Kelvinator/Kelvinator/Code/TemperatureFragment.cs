﻿using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Kelvinator.Code.Conversions;
using static Kelvinator.Code.Enums;

namespace Kelvinator.Code
{
    public class TemperatureFragment : ConversionsBase
    {
        TemperatureUnits fromTempUnit;
        TemperatureUnits toTempUnit;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            LL = (LinearLayout)inflater.Inflate(Resource.Layout.fragment_temperature, container, false);
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

        public override void SetFromUnit()
        {
            int rbId = RgFrom.CheckedRadioButtonId;
            RadioButton rb = LL.FindViewById<RadioButton>(rbId);
            string rbText = rb.Text;

            if (rbText == Strings.Celsius)
            {
                fromTempUnit = TemperatureUnits.Celsius;
            }
            else if (rbText == Strings.Kelvin)
            {
                fromTempUnit = TemperatureUnits.Kelvin;
            }
            else if (rbText == Strings.Fahrenheit)
            {
                fromTempUnit = TemperatureUnits.Fahrentheit;
            }
        }

        public override void SetToUnit()
        {
            int rbId = RgTo.CheckedRadioButtonId;
            RadioButton rb = LL.FindViewById<RadioButton>(rbId);
            string rbText = rb.Text;

            if (rbText == Strings.Celsius)
            {
                toTempUnit = TemperatureUnits.Celsius;
            }
            else if (rbText == Strings.Kelvin)
            {
                toTempUnit = TemperatureUnits.Kelvin;
            }
            else if (rbText == Strings.Fahrenheit)
            {
                toTempUnit = TemperatureUnits.Fahrentheit;
            }
        }

        public override void ConfigureEvents()
        {
            SetFromRadioButtonEvents();
            SetToRadioButtonEvents();

            Button btnConvert = LL.FindViewById<Button>(Resource.Id.btn_temp_convert);
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

        private void FromRadioButton_Click(object sender, EventArgs e)
        {
            SetFromUnit();
        }


        public override void SetToRadioButtonEvents()
        {
            RadioButton[] rbsTo = GetToRadioButtons();
            for (int i = 0; i < rbsTo.Length; i++)
            {
                rbsTo[i].Click += TemperatureFragment_Click;
            }
        }

        private void TemperatureFragment_Click(object sender, EventArgs e)
        {
            SetToUnit();
        }

        public override RadioButton[] GetFromRadioButtons()
        {
            int children = RgFrom.ChildCount;
            RadioButton[] rbs = new RadioButton[children];

            for (int i = 0; i < children; i++)
            {
                rbs[i] = RgFrom.GetChildAt(i) as RadioButton;
            }

            return rbs;
        }

        public override RadioButton[] GetToRadioButtons()
        {
            int children = RgTo.ChildCount;
            RadioButton[] rbs = new RadioButton[children];

            for (int i = 0; i < children; i++)
            {
                rbs[i] = RgTo.GetChildAt(i) as RadioButton;
            }

            return rbs;
        }

        public override void BtnConvert_Click(object sender, EventArgs e)
        {
            var conv = new TemperatureConversions(fromTempUnit, toTempUnit);

            EditText etFromTemp = LL.FindViewById<EditText>(Resource.Id.et_from_prompt);
            if (etFromTemp.Text != null)
            {
                double from = Convert.ToDouble(etFromTemp.Text);
                double toValue = conv.GetConversiondResult(from);

                EditText etTo = LL.FindViewById<EditText>(Resource.Id.et_to_prompt);
                etTo.SetText(toValue.ToString(), TextView.BufferType.Normal);
            }
        }
    }
}