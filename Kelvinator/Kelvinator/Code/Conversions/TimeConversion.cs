using System.Collections.Generic;
using Time = KelvinatorX.Code.Enums.TimeUnits;

namespace KelvinatorX.Code.Conversions
{
    public class TimeConversion
    {
        Time fromTime;
        Time toTime;

        public Dictionary<Time, double> ConversionFactors { get; set; }

        public TimeConversion(Time from, Time to)
        {
            this.fromTime = from;
            this.toTime = to;

            ConversionFactors = GetConversionFactors();
        }

        private Dictionary<Time, double> GetConversionFactors()
        {
            var t = new Dictionary<Time, double>
            {
                { Time.Hour, 1.0 },
                { Time.Picosecond, 3.6e+15 },
                { Time.Nanosecond, 3600002880000.6713867 },
                { Time.Microsecond, 3.6e+9 },
                { Time.Millisecond, 3.6e+6 },
                { Time.Second, 3600 },
                { Time.Minute, 60 },
                { Time.Day, 0.0416667 },
                { Time.Week, 0.00595238 },
                { Time.Month, 0.00136986260837 },
                { Time.Year, 0.00011415534246577472655 }

            };

            return t;
        }

        public double GetConversionResult(double input)
        {
            //TODO: Add error checking.
            ConversionFactors.TryGetValue(fromTime, out double fromFactor);
            ConversionFactors.TryGetValue(toTime, out double toFactor);

            return input * fromFactor / toFactor;
        }
    }
}