using System;
using System.Collections.Generic;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code.Conversions
{
    public abstract class BaseConversions
    {
        public object FromUnit { get; set; }
        public object ToUnit { get; set; }
        
        public Dictionary<object, double> ConversionFactors { get; set; }

        public abstract Dictionary<object, double> GetConversionFactors();

        public double GetConversionResult(double input)
        {
            ConversionFactors.TryGetValue(FromUnit, out double fromFactor);
            ConversionFactors.TryGetValue(ToUnit, out double toFactor);
                        
            return Math.Round(input * fromFactor / toFactor, GetRoundToDecimalsValue(), MidpointRounding.AwayFromZero);
        }

        public abstract int GetRoundToDecimalsValue();
    }
}