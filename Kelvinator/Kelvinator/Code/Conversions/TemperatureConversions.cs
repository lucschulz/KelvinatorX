﻿using System;
using System.Collections.Generic;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code.Conversions
{
    public class TemperatureConversions : BaseConversions
    {
        public TemperatureConversions(TemperatureUnits fromTempUnit, TemperatureUnits toTempUnit)
        {
            base.FromUnit = fromTempUnit;
            base.ToUnit = toTempUnit;
        }

        public override Dictionary<object, double> GetConversionFactors()
        {
            var t = new Dictionary<object, double>
            {
                { TemperatureUnits.Celsius, 1.0 },
                { TemperatureUnits.Fahrentheit, 1.8 },
                { TemperatureUnits.Kelvin, 273.15 }
            };

            return t;
        }

        public override int GetRoundToDecimalsValue()
        {
            TemperatureUnits toUnit = (TemperatureUnits)ToUnit;

            switch (toUnit)
            {
                case TemperatureUnits.Celsius:
                case TemperatureUnits.Kelvin:
                case TemperatureUnits.Fahrentheit:
                    return 3;
            }

            throw new Exception("The 'TO' unit enum was improperly defined.");
        }
    }
}