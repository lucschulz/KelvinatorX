using System.Collections.Generic;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code.Conversions
{
    public class TimeConversions : BaseConversions
    {
        public TimeConversions(TimeUnits from, TimeUnits to)
        {
            base.FromUnit = from;
            base.ToUnit = to;

            ConversionFactors = GetConversionFactors();
        }

        public override Dictionary<object, double> GetConversionFactors()
        {
            var t = new Dictionary<object, double>
            {
                { TimeUnits.Hour, 1.0 },
                { TimeUnits.Picosecond, 3.6e+15 },
                { TimeUnits.Nanosecond, 3600002880000.6713867 },
                { TimeUnits.Microsecond, 3.6e+9 },
                { TimeUnits.Millisecond, 3.6e+6 },
                { TimeUnits.Second, 3600 },
                { TimeUnits.Minute, 60 },
                { TimeUnits.Day, 0.0416667 },
                { TimeUnits.Week, 0.00595238 },
                { TimeUnits.Month, 0.00136986260837 },
                { TimeUnits.Year, 0.00011415534246577472655 }

            };

            return t;
        }

        public override double GetConversionResult(double input)
        {
            //TODO: Add error checking.
            ConversionFactors.TryGetValue((TimeUnits)base.FromUnit, out double fromFactor);
            ConversionFactors.TryGetValue((TimeUnits)base.ToUnit, out double toFactor);

            return input * fromFactor / toFactor;
        }
    }
}