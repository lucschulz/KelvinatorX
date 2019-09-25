using System;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace KelvinatorX.Code
{
    public abstract class ConversionsBase : Fragment
    {
        /// <summary>
        /// Some fragments are using a linear layout as their base layout.
        /// This should eventually be changed to scroll layouts across the board.
        /// </summary>
        public virtual LinearLayout LL { get; set; }


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
        /// Implement in derived class to configure the events associated to clicking a 'FROM' RadioButton.
        /// </summary>
        public abstract void SetFromRadioButtonEvents();


        /// <summary>
        /// Implement in derived class to configure the events associated to clicking a 'TO' RadioButton.
        /// </summary>
        public abstract void SetToRadioButtonEvents();


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


        public abstract void SetFromUnit();


        public abstract void SetToUnit();


        /// <summary>
        /// Sets the most recently clicked RadioButton to be the current unit for calculations.
        /// </summary>
        /// <param name="rbText">The text of the RadioButton that was selected. 
        ///     They are matched in the Strings namespace.
        /// </param>
        /// <returns>Returns an object that can be cast to an Enum from the Enums class.</returns>
        public abstract object SetUnit(string rbText);


        public abstract void ConfigureEvents();


        /// <summary>
        /// Called when the 'CONVERT' button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void BtnConvert_Click(object sender, EventArgs e);


        public void FromRadioButton_Click(object sender, EventArgs e)
        {
            SetFromUnit();
        }


        public void ToRadioButton_Click(object sender, EventArgs e)
        {
            SetToUnit();
        }
    }
}