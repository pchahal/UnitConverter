using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ConverterFramework;


namespace UnitConverter.Tests
{
    class CalculatorTests
    {
        [Test]
        public void convertUnitEmptyUnitReturns0()
        {            
            
            Calculator calc = new Calculator();
            Unit emptyUnit = new Unit() {measurement = 0, fromUnit = Units.Unknown, toUnit = Units.Unknown};
            float actual = calc.convertUnit(emptyUnit);
            Assert.AreEqual(0, actual);
        }


        [Test]
        public void convertUnit5MetresToFeetReturns60()
        {
            Calculator calc = new Calculator();
            Unit unit = new Unit() { measurement = 5, fromUnit = Units.Metre, toUnit = Units.Feet };
            float actual = calc.convertUnit(unit);

            Assert.That(actual, Is.EqualTo(16.4042).Within(.0001));
        }

         [Test]
        public void convertUnit10MilesToKilometresReturns16_0934()
        {
            Calculator calc = new Calculator();
            Unit unit = new Unit() { measurement = 10, fromUnit = Units.Mile , toUnit = Units.Kilometre };
            float actual = calc.convertUnit(unit);

            Assert.That(actual, Is.EqualTo(16.09300004).Within(.0001));
        }

       

       
    }
}
