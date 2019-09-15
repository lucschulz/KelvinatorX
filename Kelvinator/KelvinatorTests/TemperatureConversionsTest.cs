﻿using System;
using Kelvinator.Code.Conversions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Temp = Kelvinator.Code.Enums.TemperatureUnits;

namespace KelvinatorTests
{
    [TestClass]
    public class TemperatureConversionsTest
    {
        [TestMethod]
        public void FtoK()
        {
            var t = new TemperatureConversions(Temp.Fahrentheit, Temp.Kelvin);

            double f = t.GetConversiondResult(10);
            double k = 260.93;

            Assert.AreEqual(f, k);

            f = t.GetConversiondResult(0);
            k = 255.37;

            Assert.AreEqual(f, k);
        }


        [TestMethod]
        public void FtoC()
        {
            var t = new TemperatureConversions(Temp.Fahrentheit, Temp.Kelvin);

            double f = t.GetConversiondResult(-32);
            double k = 237.59;

            Assert.AreEqual(f, k);
        }


        [TestMethod]
        public void CtoK()
        {
            var t = new TemperatureConversions(Temp.Celsius, Temp.Kelvin);

            double c = t.GetConversiondResult(-273.15);
            double k = 0;

            Assert.AreEqual(c, k);
        }


        [TestMethod]
        public void CtoF()
        {
            var t = new TemperatureConversions(Temp.Celsius, Temp.Fahrentheit);

            double c = t.GetConversiondResult(0);
            double f = 32;

            Assert.AreEqual(c, f);
        }


        [TestMethod]
        public void KtoC()
        {
            var t = new TemperatureConversions(Temp.Kelvin, Temp.Celsius);

            double k = t.GetConversiondResult(-273.15);
            double c = 0;

            Assert.AreEqual(k, c);
        }


        [TestMethod]
        public void KtoF()
        {
            var t = new TemperatureConversions(Temp.Kelvin, Temp.Fahrentheit);

            double k = t.GetConversiondResult(-45);
            double f = -540.67;

            Assert.AreEqual(k, f);
        }
    }
}