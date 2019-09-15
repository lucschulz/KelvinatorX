using System;
using Dist = Kelvinator.Code.Enums.DistanceUnits;

namespace Kelvinator.Code.Conversions
{
    public class DistanceConversions
    {
        Dist fromDistance;
        Dist toDistance;


        public DistanceConversions(Dist from, Dist to)
        {
            this.fromDistance = from;
            this.toDistance = to;
        }

    }
}