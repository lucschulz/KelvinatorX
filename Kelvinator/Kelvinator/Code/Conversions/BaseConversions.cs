using System.Collections.Generic;

namespace KelvinatorX.Code.Conversions
{
    public abstract class BaseConversions
    {
        public object FromUnit { get; set; }
        public object ToUnit { get; set; }
        
        public Dictionary<object, double> ConversionFactors { get; set; }

        public abstract Dictionary<object, double> GetConversionFactors();

        public abstract double GetConversionResult(double input);
    }
}