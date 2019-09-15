using Android.Support.V4.App;
using Android.Widget;
using System;

namespace Kelvinator.Code
{
    public abstract class ConversionsBase : Fragment
    {
        public LinearLayout LL { get; set; }
        public RadioGroup RgFrom { get; set; }
        public RadioGroup RgTo { get; set; }

        public abstract void ConfigureControls();

        public abstract void SetFromUnit();

        public abstract void SetToUnit();

        public abstract void ConfigureEvents();

        public abstract void SetFromRadioButtonEvents();

        public abstract void SetToRadioButtonEvents();

        public abstract RadioButton[] GetFromRadioButtons();

        public abstract RadioButton[] GetToRadioButtons();

        public abstract void BtnConvert_Click(object sender, EventArgs e);
    }
}