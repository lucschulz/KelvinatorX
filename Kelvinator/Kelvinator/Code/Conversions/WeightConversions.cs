using System.Collections.Generic;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code.Conversions
{
    public class WeightConversions : BaseConversions
    {
        public WeightConversions(WeightUnits from, WeightUnits to)
        {
            base.FromUnit = from;
            base.ToUnit = to;

            ConversionFactors = GetConversionFactors();
        }

        public override Dictionary<object, double> GetConversionFactors()
        {
            var w = new Dictionary<object, double>
            {
                { WeightUnits.Kilogram, 1.0 },
                { WeightUnits.Gram, 1000.0 },
                { WeightUnits.Milligram, 1.0e+6 },
                { WeightUnits.MetricTon, 0.001 },
                { WeightUnits.LongTon, 0.000984207 },
                { WeightUnits.ShortTon, 0.00110231 },
                { WeightUnits.Pound, 2.20462 },
                { WeightUnits.Ounce, 35.274 },
                { WeightUnits.Carrat, 5000 },
                { WeightUnits.AtomicMassUnit, 6.022e+26 }
            };

            return w;
        }

        public override double GetConversionResult(double input)
        {
            //TODO: Add error checking.
            ConversionFactors.TryGetValue((WeightUnits)base.FromUnit, out double fromFactor);
            ConversionFactors.TryGetValue((WeightUnits)base.ToUnit, out double toFactor);

            return input * fromFactor / toFactor;
        }
    }
}