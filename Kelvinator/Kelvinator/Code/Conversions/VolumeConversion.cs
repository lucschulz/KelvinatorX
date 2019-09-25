using System.Collections.Generic;
using static KelvinatorX.Code.Enums;

namespace KelvinatorX.Code.Conversions
{
    public class VolumeConversion
    {
        readonly VolumeUnits fromVolume;
        readonly VolumeUnits toVolume;

        public Dictionary<VolumeUnits, double> ConversionFactors { get; set; }

        public VolumeConversion(VolumeUnits from, VolumeUnits to)
        {
            this.fromVolume = from;
            this.toVolume = to;

            ConversionFactors = GetConversionFactors();
        }

        private Dictionary<VolumeUnits, double> GetConversionFactors()
        {
            var v = new Dictionary<VolumeUnits, double>
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
                { VolumeUnits.US_Gallon, 0.26 }

            };

            return v;
        }

        public double GetConversionResult(double input)
        {
            //TODO: Add error checking.
            ConversionFactors.TryGetValue(fromVolume, out double fromFactor);
            ConversionFactors.TryGetValue(toVolume, out double toFactor);

            return input * fromFactor / toFactor;
        }
    }
}