using System.Collections.Generic;
using Dist = Kelvinator.Code.Enums.DistanceUnits;

namespace Kelvinator.Code.Conversions
{
    public class DistanceConversions
    {
        Dist fromDistance;
        Dist toDistance;

        public Dictionary<Dist, double> ConversionFactors { get; set; }


        public DistanceConversions(Dist from, Dist to)
        {
            this.fromDistance = from;
            this.toDistance = to;

            ConversionFactors = GetConversionFactors();
        }

        private Dictionary<Dist, double> GetConversionFactors()
        {
            Dictionary<Dist, double> d = new Dictionary<Dist, double>
            {
                { Dist.Nanometer, 1.0e-9 },
                { Dist.Millimeter, 0.001 },
                { Dist.Centimeter, 0.01 },
                { Dist.Meter, 1.0 },
                { Dist.Kilometer, 1000.0 },
                { Dist.Inch, 0.0000254 },
                { Dist.Foot, 0.0003048 },
                { Dist.Yard, 0.0009144 },
                { Dist.Mile, 1.609344 },
                { Dist.AstronomicalUnit, 149598073000 },
                { Dist.LightYear, 9.4607304725808e15 }
            };

            return d;
        }

        public double GetResult(double input)
        {
            //TODO: Add error checking.
            ConversionFactors.TryGetValue(fromDistance, out double from);
            ConversionFactors.TryGetValue(toDistance, out double to);

            return input * from / to;
        }
    }
}