using System;
using System.Collections.Generic;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code.Conversions
{
    public class VolumeConversions : BaseConversions
    {
        public VolumeConversions(VolumeUnits from, VolumeUnits to)
        {
            this.FromUnit = from;
            this.ToUnit = to;

            ConversionFactors = GetConversionFactors();
        }

        public override Dictionary<object, double> GetConversionFactors()
        {
            var v = new Dictionary<object, double>
            {
                { VolumeUnits.Liter, 1.0 },
                { VolumeUnits.Milliliter, 1000.0 },
                { VolumeUnits.CubicCentimeter, 1000.0 },
                { VolumeUnits.CubicMeter, 0.001 },
                { VolumeUnits.CubicKilometer, 1.0e-12 },
                { VolumeUnits.ImperialFluidOunce, 35.1951 },
                { VolumeUnits.ImperialFluidPint, 1.76 },
                { VolumeUnits.ImperialFluidQuart, 0.88 },
                { VolumeUnits.ImperialGallon, 0.22 },
                { VolumeUnits.USGallon, 0.26 }

            };

            return v;
        }

        public override int GetRoundToDecimalsValue()
        {
            VolumeUnits toUnit = (VolumeUnits)ToUnit;

            switch (toUnit)
            {
                case VolumeUnits.CubicMillimeter:
                case VolumeUnits.Milliliter:
                case VolumeUnits.ImperialFluidOunce:
                    return 5;
                case VolumeUnits.CubicMeter:
                case VolumeUnits.CubicCentimeter:
                    return 3;
                case VolumeUnits.CubicKilometer:
                case VolumeUnits.USGallon:
                case VolumeUnits.ImperialGallon:
                case VolumeUnits.ImperialFluidQuart:
                case VolumeUnits.ImperialFluidPint:
                case VolumeUnits.Liter:
                    return 2;
            }

            throw new Exception("The 'TO' unit enum was improperly defined.");
        }
    }
}