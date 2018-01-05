using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ConverterFramework;

// this class takes a list of strings, and it returns back an object (value,fromUnit,toUnit) eg "5 metres to feet" returns UnitObject(5,unit.metres,unit.feet)

namespace UnitConverter.Tests
{
    [TestFixture]
    public class UnitConversionTests
    {
        
        [Test]
        public void HasThreeArgsValidStringReturnsUnitObject()
        {
            UnitConversion unitConvert = new UnitConversion();
            Unit unit = unitConvert.GetUnits("5 FEET TO MILES");                        
            Assert.IsNotNull(unit);
        }

        [Test]
        public void IsNullEmptyStringReturnsEmptyUnitObject()
        {
            UnitConversion unitConvert = new UnitConversion();
            Unit emptyUnit = new Unit();
            emptyUnit.fromUnit = Units.Unknown;
            emptyUnit.toUnit = Units.Unknown;
            emptyUnit.measurement = 0;
            Unit unit = unitConvert.GetUnits("");
            Assert.AreEqual(emptyUnit ,unit);
        }


        [Test]
        public void FiveFeetToMilesValidStringReturns5ForMeasurement()
        {
            UnitConversion unitConvert = new UnitConversion();
            Unit expectedUnit = new Unit();
            expectedUnit.fromUnit = Units.Feet;
            expectedUnit.toUnit = Units.Mile;
            expectedUnit.measurement = 5;
            Unit unit = unitConvert.GetUnits("5 FEET TO MILES");
            Assert.AreEqual(expectedUnit, unit);
        }

        [Test]
        public void TenMilesToKilometresValidStringReturns10ForMeasurement()
        {
            UnitConversion unitConvert = new UnitConversion();
            Unit expectedUnit = new Unit();
            expectedUnit.fromUnit = Units.Mile;
            expectedUnit.toUnit = Units.Kilometre;
            expectedUnit.measurement = 10;
            Unit unit = unitConvert.GetUnits("10 miles to kilometers");
            Assert.AreEqual(expectedUnit, unit);
        }

        [Test]
        public void TenMilesToKiloTONSReturnsUNKNOWNForToUnit()
        {
            UnitConversion unitConvert = new UnitConversion();
            Unit expectedUnit = new Unit();
            expectedUnit.fromUnit = Units.Mile;
            expectedUnit.toUnit = Units.Unknown;
            expectedUnit.measurement = 10;
            Unit unit = unitConvert.GetUnits("10 miles to kiloTONS");
            Assert.AreEqual(expectedUnit, unit);
        }

      
        [Test]
        public void JunkFeetToInchesReturns0ForMeasurement()
        {
            UnitConversion unitConvert = new UnitConversion();
            Unit expectedUnit = new Unit();
            expectedUnit.fromUnit = Units.Feet;
            expectedUnit.toUnit = Units.Inch;
            expectedUnit.measurement = 0;
            Unit unit = unitConvert.GetUnits("xyz feet to inches");
            Assert.AreEqual(expectedUnit, unit);
        }

    }
}
