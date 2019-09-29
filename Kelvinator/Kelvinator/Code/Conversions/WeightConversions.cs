using System;
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

        public override int GetRoundToDecimalsValue()
        {
            WeightUnits toUnit = (WeightUnits)ToUnit;

            switch (toUnit)
            {
                case WeightUnits.Pound:
                case WeightUnits.Ounce:
                case WeightUnits.Carrat:
                case WeightUnits.Kilogram:                    
                case WeightUnits.Gram:                    
                case WeightUnits.Milligram:
                    return 3;

                case WeightUnits.MetricTon:
                case WeightUnits.ShortTon:
                case WeightUnits.LongTon:
                    return 2;
                                    
                case WeightUnits.AtomicMassUnit:
                    return 1;
                    
            }

            throw new Exception("The 'TO' unit enum was improperly defined.");
        }
    }
}