using System;
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


        /// <summary>
        /// Base unit is the minute.
        /// </summary>
        /// <returns>Returns the conversion factor for the output value.</returns>
        public override Dictionary<object, double> GetConversionFactors()
        {
            var t = new Dictionary<object, double>
            {
                { TimeUnits.Picosecond, 3.6e+15 },
                { TimeUnits.Nanosecond, 6e+10 },
                { TimeUnits.Microsecond, 6e+7 },
                { TimeUnits.Millisecond, 6e+4 },
                { TimeUnits.Second, 60 },
                { TimeUnits.Minute, 1.0 },
                { TimeUnits.Hour, 0.016667 },
                { TimeUnits.Day, 0.0416667 },
                { TimeUnits.Week, 0.00595238 },
                { TimeUnits.Month, 0.00136986260837 },
                { TimeUnits.Year, 0.00011415534246577472655 }

            };

            return t;
        }

        public override int GetRoundToDecimalsValue()
        {
            TimeUnits toUnit = (TimeUnits)ToUnit;

            switch (toUnit)
            {
                case TimeUnits.Second:
                case TimeUnits.Millisecond:
                case TimeUnits.Microsecond:
                case TimeUnits.Nanosecond:
                case TimeUnits.Picosecond:
                    return 5;

                case TimeUnits.Minute:
                    return 2;

                case TimeUnits.Hour:
                case TimeUnits.Day:
                case TimeUnits.Week:
                case TimeUnits.Month:
                case TimeUnits.Year:
                    return 1;
            }

            throw new Exception("The 'TO' unit enum was improperly defined.");
        }
    }
}