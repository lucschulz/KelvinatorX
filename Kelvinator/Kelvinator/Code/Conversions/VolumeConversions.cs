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
    }
}