using Android.Support.V4.App;
using Android.Widget;
using System;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code
{
    public abstract class ConversionsBase : Fragment
    {
        public virtual LinearLayout LL { get; set; }
        public RadioGroup RgFrom { get; set; }
        public RadioGroup RgTo { get; set; }

        public abstract void ConfigureControls();

        public abstract void SetFromUnit();

        public abstract void SetToUnit();

        public abstract DistanceUnits SetUnit(string rbText);

        public abstract void ConfigureEvents();

        public abstract void SetFromRadioButtonEvents();

        public abstract void SetToRadioButtonEvents();

        public RadioButton[] GetFromRadioButtons()
        {
            int children = RgFrom.ChildCount;
            RadioButton[] rbs = new RadioButton[children];

            for (int i = 0; i < children; i++)
            {
                rbs[i] = RgFrom.GetChildAt(i) as RadioButton;
            }

            return rbs;
        }

        public RadioButton[] GetToRadioButtons()
        {
            int children = RgTo.ChildCount;
            RadioButton[] rbs = new RadioButton[children];

            for (int i = 0; i < children; i++)
            {
                rbs[i] = RgTo.GetChildAt(i) as RadioButton;
            }

            return rbs;
        }

        public abstract void BtnConvert_Click(object sender, EventArgs e);
    }
}