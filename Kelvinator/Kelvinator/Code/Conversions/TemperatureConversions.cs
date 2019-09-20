using System;
using Temp = KelvinatorX.Code.Enums.TemperatureUnits;

namespace KelvinatorX.Code.Conversions
{
    public class TemperatureConversions
    {
        Temp fromUnit;
        Temp toUnit;


        public TemperatureConversions(Temp fromTempUnit, Temp toTempUnit)
        {
            fromUnit = fromTempUnit;
            toUnit = toTempUnit;
        }


        private double CtoK(double c)
        {            
            return Math.Round(c + 273.15, 2);
        }

        private double CtoF(double c)
        {
            return c * 1.80 + 32;
        }

        private double KtoC(double k)
        {
            return Math.Round(k + 273.15);
        }

        private double KtoF(double k)
        {
            double result = k * 1.80 - 459.67;
            return Math.Round(result, 2);
        }

        private double FtoC(double f)
        {
            return Math.Round((f - 32) / 1.8);
        }

        private double FtoK(double f)
        {
            double result = f + 459.67;

            if (result != 0)
            {
                return Math.Round(result * 5 / 9, 2);
            }
            
            return 0;
        }




        public double GetConversiondResult(double from)
        {
            if (fromUnit == Temp.Celsius)
            {
                return GetFromCelsius(from);
            }

            else if (fromUnit == Temp.Kelvin)
            {
                return GetFromKelvin(from);
            }

            else if (fromUnit == Temp.Fahrentheit)
            {
                return GetFromFahrenheit(from);
            }

            return 0;
        }

        private double GetFromCelsius(double c)
        {
            if (toUnit == Temp.Kelvin)
            {
                return CtoK(c);
            }
            else if (toUnit == Temp.Fahrentheit)
            {
                return CtoF(c);
            }

            return 0;
        }

        private double GetFromKelvin(double k)
        {
            if (toUnit == Temp.Celsius)
            {
                return KtoC(k);
            }
            else if (toUnit == Temp.Fahrentheit)
            {
                return KtoF(k);
            }

            return 0;
        }

        private double GetFromFahrenheit(double f)
        {
            if (toUnit == Temp.Celsius)
            {
                return FtoC(f);
            }
            else if (toUnit == Temp.Kelvin)
            {
                return FtoK(f);
            }

            return 0;
        }
    }
}