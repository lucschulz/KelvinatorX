using System;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace KelvinatorX.Code
{
    public abstract class BaseFragment : Fragment
    {
        public int FromUnitType { get; set; }
        public int ToUnitType { get; set; }


        /// <summary>
        /// Linear layouts need to be replaces with scroll layouts so that the keyboard
        /// doesn't make it impossible to use the rest of the screen when it pops up.
        /// </summary>
        public virtual ScrollView SV { get; set; }


        /// <summary>
        /// A RadioGroup object containing all the 'FROM' RadioButtons.
        /// </summary>
        public RadioGroup RgFrom { get; set; }


        /// <summary>
        /// A RadioGroup object containing all the 'TO' RadioButtons.
        /// </summary>
        public RadioGroup RgTo { get; set; }


        /// <summary>
        /// Places the radio buttons in the 'FROM' group of the current fragment in an array.
        /// </summary>
        /// <returns>An array of radio buttons representing the units being converted from.</returns>
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


        /// <summary>
        /// Places the radio buttons in the 'TO' group of the current fragment in an array.
        /// </summary>
        /// <returns>An array of radio buttons representing the units to convert towards.</returns>
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


        /// <summary>
        /// Creates an array of all the 'FROM' radio buttons.
        /// </summary>
        public void SetFromRadioButtonEvents()
        {
            RadioButton[] rbsFrom = GetFromRadioButtons();
            for (int i = 0; i < rbsFrom.Length; i++)
            {
                rbsFrom[i].Click += FromRadioButton_Click;
            }
        }
        public void FromRadioButton_Click(object sender, EventArgs e)
        {
            SetFromUnit();
        }


        /// <summary>
        /// Creates an array of all the 'TO' radio buttons.
        /// </summary>
        public void SetToRadioButtonEvents()
        {
            RadioButton[] rbsTo = GetToRadioButtons();
            for (int i = 0; i < rbsTo.Length; i++)
            {
                rbsTo[i].Click += ToRadioButton_Click;
            }
        }
        public void ToRadioButton_Click(object sender, EventArgs e)
        {
            SetToUnit();
        }


        /// <summary>
        /// Use to run the Setting Methods and assign the public properties of the base class.
        /// </summary>
        public void ConfigureControls()
        {
            SetFromUnit();
            SetToUnit();
            ConfigureEvents();

            Activity.Window.SetSoftInputMode(SoftInput.AdjustResize);
        }


        public virtual void SetFromUnit()
        {
            int rbId = RgFrom.CheckedRadioButtonId;
            RadioButton rb = SV.FindViewById<RadioButton>(rbId);
            string rbText = rb.Text;

            FromUnitType = (int)SetUnit(rbText);
        }


        public virtual void SetToUnit()
        {
            int rbId = RgTo.CheckedRadioButtonId;
            RadioButton rb = SV.FindViewById<RadioButton>(rbId);
            string rbText = rb.Text;

            ToUnitType = (int)SetUnit(rbText);
        }


        /// <summary>
        /// Sets the most recently clicked RadioButton to be the current unit for calculations.
        /// </summary>
        /// <param name="rbText">The text of the RadioButton that was selected. 
        ///     They are matched in the Strings namespace.
        /// </param>
        /// <returns>Returns an object that can be cast to an Enum from the Enums class.</returns>
        public abstract object SetUnit(string rbText);


        public void ConfigureEvents()
        {
            SetFromRadioButtonEvents();
            SetToRadioButtonEvents();

            Button btnConvert = SV.FindViewById<Button>(Resource.Id.btn_convert);
            btnConvert.Click += BtnConvert_Click;
        }


        /// <summary>
        /// Called when the 'CONVERT' button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void BtnConvert_Click(object sender, EventArgs e);
    }
}