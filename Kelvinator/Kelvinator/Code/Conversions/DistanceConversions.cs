﻿using System;
using System.Collections.Generic;
using Dist = KelvinatorX.Code.Enums.DistanceUnits;

namespace KelvinatorX.Code.Conversions
{
    public class DistanceConversions : BaseConversions
    {
        public DistanceConversions(Dist from, Dist to)
        {
            base.FromUnit = from;
            this.ToUnit = to;

            ConversionFactors = GetConversionFactors();
        }

        public override Dictionary<object, double> GetConversionFactors()
        {
            var d = new Dictionary<object, double>
            {
                { Dist.Nanometer, 1.0e-9 },
                { Dist.Millimeter, 0.001 },
                { Dist.Centimeter, 0.01 },
                { Dist.Meter, 1.0 },
                { Dist.Kilometer, 1000.0 },
                { Dist.Inch, 39.37 },
                { Dist.Foot, 3.2809 },
                { Dist.Yard, 1.0936 },
                { Dist.Mile, 1609.344497892563 },
                { Dist.AstronomicalUnit, 149598073000 },
                { Dist.LightYear, 9.4607304725808e15 }
            };

            return d;
        }

        public override int GetRoundToDecimalsValue()
        {
            Dist toUnit = (Dist)ToUnit;

            switch (toUnit)
            {
                case Dist.Centimeter:
                case Dist.Millimeter:
                case Dist.Nanometer:
                    return 5;

                case Dist.Meter:
                case Dist.Kilometer:
                case Dist.Yard:
                case Dist.Foot:
                case Dist.Inch:
                case Dist.Mile:
                    return 2;
                    
                case Dist.AstronomicalUnit:                    
                case Dist.LightYear:
                    return 1;
                    
            }

            throw new Exception("The 'TO' unit enum was improperly defined.");
        }
    }
}