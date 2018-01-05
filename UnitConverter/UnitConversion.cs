
using System;
using System.Collections.Generic;
using System.ComponentModel;
using ConverterFramework;


namespace ConverterFramework
{
    public enum Units
    {
      
        Unknown,
        Acre,
        Hectare,
        Squarefoot,
        Squaremetre,
        Squarekilometre,
        Squareinch,
        Squareyard,
        Squaremile,
        Millimetre,
        Centimetre,
        Decimetre,
        Metre,
        Kilometre,
        Feet,
        Inch,
        Mile,
        Yard,
        Fahrenheit,
        Celsius,
        Kelvin,
        Day,
        Hour,
        Second,
        Minute,
        Year,
        Cubicfoot,
        Cubicinch,
        Cubicmile,
        Cubicyard,
        Cup,        
        Liter,
        Ounce,              
        Tablespoon,
        Teaspoon,
        Milligram,
        Gram,
        Kilogram,
        Carat,
        Pound,
        Tonne,
        Millilitre,
        OunceUsFluid,
        OunceImpFluid,
        GallonImp,
        GallonUs,
        PintImp,
        PintUsDry,
        PintUsLiquid,
        QuartImp,
        QuartUsDry,        
        QuartUsLiquid,

    }
   


    public class Unit
    {
        public float measurement { get; set; }
        public Units fromUnit { get; set; }
        public Units toUnit { get; set; }
        public float result { get; set; }
        public override bool Equals(object obj)
        {
            Unit o = (Unit) obj;

            if (o.fromUnit == this.fromUnit && o.toUnit == this.toUnit && o.measurement == this.measurement)
                return true;
            else
                return false;


        }
        public bool isValid()
        {
            UnitKey key = new UnitKey();
            key.fromUnit = fromUnit;
            key.toUnit = toUnit;
            
            Calculator calc= new Calculator();
            if (calc.unitDictionary.ContainsKey(key))
               return true;                            
            else
                return false;
        }

        public  string resultString()
        {
            string unitDesc = getUnitDescription(toUnit);


            string description = result.ToString() + " " + unitDesc + ("s"); 
            return description;
        }
        public string queryString()
        {
            string unitDesc = getUnitDescription(fromUnit);
            string description = measurement.ToString() + " " + unitDesc + "(s) =";
            return description;
        }

        public string getUnitDescription(Units u)
        {
            if (u == Units.Squarefoot)
                return "Square Feet";
            else if (u == Units.Squaremetre)
                return "Square Metre";
            else if (u == Units.Squarekilometre)
                return "Square Kilometer";
            else if (u == Units.Squareinch)
                return "Square Inch";
            else if (u == Units.Squareyard)
                return "Square Yard";
            else if (u == Units.Squaremile)
                return "Square Mile";
            else if (u == Units.Cubicfoot)
                return "Cubic Feet";
            else if (u == Units.Cubicinch)
                return "Cubic Inch";
            else if (u == Units.Cubicmile)
                return "Cubic Mile";
            else if (u == Units.Cubicyard)
                return "Cubic Yard";
            else if (u == Units.OunceUsFluid)
                return "US Fluid Ounce";
            else if (u == Units.OunceImpFluid)
                return "Imperial Fluid Ounce";
            else if (u == Units.GallonImp)
                return "Imperial Gallon";
            else if (u == Units.GallonUs)
                return "US Gallon";
            else if (u == Units.PintImp)
                return "Imperial Pint";
            else if (u == Units.PintUsDry)
                return "US Dry Pint";
            else if (u == Units.PintUsLiquid)
                return "US Liquid Pint";
            else if (u == Units.QuartImp)
                return "Imperial Quart";
            else if (u == Units.QuartUsDry)
                return "US Dry Quart";
            else if (u == Units.QuartUsLiquid)
                return "US Liquid Quart";

            else
                return u.ToString();
        }
    }

    }

    public  class UnitConversion
    {
        private Dictionary<string, Units> unitDictionary = new Dictionary<string, Units>
                                                               {
                                                                   //AREA
                                                                   {"ACRE",             Units.Acre},           {"ACRES",            Units.Acre},
                                                                   {"HECTARE",          Units.Hectare},        {"HECTARES",         Units.Hectare},
                                                                   {"SQUARE FOOT",      Units.Squarefoot},     {"SQUARE FEET",      Units.Squarefoot},
                                                                   {"SQUARE METER",     Units.Squaremetre},    {"SQUARE METRE",     Units.Squaremetre},    {"SQUARE METERS",     Units.Squaremetre},    {"SQUARE METRES",       Units.Squaremetre},
                                                                   {"SQUARE KILOMETRE", Units.Squarekilometre},{"SQUARE KILOMETER", Units.Squarekilometre},{"SQUARE KILOMETRES", Units.Squarekilometre},{"SQUARE KILOMETERS",   Units.Squarekilometre},
                                                                   {"SQUARE INCH",      Units.Squareinch},     {"SQUARE INCHES",    Units.Squareinch},
                                                                   {"SQUARE YARD",      Units.Squareyard},     {"SQUARE YARDS",     Units.Squareyard},                                                                   
                                                                   {"SQUARE MILE",      Units.Squaremile},     {"SQUARE MILES",     Units.Squaremile},
                                                                   
                                                                   

                                                                   //LENGTH
                                                                   {"MILLIMETRE",   Units.Millimetre},{"MILLIMETER",   Units.Millimetre},{"MILLIMETRES",   Units.Millimetre},{"MILLIMETERS",   Units.Millimetre},
                                                                   {"CENTIMETRE",   Units.Centimetre},{"CENTIMETER",   Units.Centimetre},{"CENTIMETRES",   Units.Centimetre},{"CENTIMETERS",   Units.Centimetre},
                                                                   {"DECIMETRE",    Units.Decimetre}, {"DECIMETER",    Units.Decimetre}, {"DECIMETRES",    Units.Decimetre}, {"DECIMETERS",   Units.Decimetre},
                                                                   {"METRE",        Units.Metre},     {"METER",        Units.Metre},    {"METRES",         Units.Metre},     {"METERS",       Units.Metre},
                                                                   {"KILOMETER",    Units.Kilometre}, {"KILOMETRE",    Units.Kilometre}, {"KILOMETERS",    Units.Kilometre}, {"KILOMETRES",   Units.Kilometre},
                                                                   {"FOOT",         Units.Feet},      {"FEET",         Units.Feet},
                                                                   {"INCH",         Units.Inch},      {"INCHES",       Units.Inch},                                                                   
                                                                   {"MILE",         Units.Mile},      {"MILES",        Units.Mile},
                                                                   {"YARD",         Units.Yard},      {"YARDS",        Units.Yard},
                                                                  
                                                                   //TEMPERTURE
                                                                   {"FAHRENHEIT",      Units.Fahrenheit},
                                                                   {"CELSIUS",         Units.Celsius},
                                                                   {"KELVIN",          Units.Kelvin},

                                                                   //TIME
                                                                   {"DAY",          Units.Day},   {"DAYS",          Units.Day},
                                                                   {"HOUR",         Units.Hour},  {"HOURS",         Units.Hour},
                                                                   {"SECOND",       Units.Second}, {"SECONDS",       Units.Second},
                                                                   {"MINUTE",       Units.Minute},{"MINUTES",       Units.Minute},
                                                                   {"YEAR",         Units.Year},  {"YEARS",         Units.Year},

                                                                   //VOLUME
                                                                   {"CUBIC FOOT",          Units.Cubicfoot},   {"CUBIC FEET",          Units.Cubicfoot},
                                                                   {"CUBIC INCH",          Units.Cubicinch},   {"CUBIC INCHES",        Units.Cubicinch},
                                                                   {"CUBIC MILE",          Units.Cubicmile},   {"CUBIC MILES",         Units.Cubicmile},
                                                                   {"CUBIC YARD",          Units.Cubicyard},  {"CUBIC YARDS",         Units.Cubicyard},
                                                                   {"CUP",                 Units.Cup},         {"CUPS",                Units.Cup},                                                                  
                                                                   {"GALLON",              Units.GallonUs},    {"GALLONS",              Units.GallonUs},    
                                                                   {"LITER",               Units.Liter},       {"LITERS",              Units.Liter},        {"LITRE",          Units.Liter},        {"LITRES",              Units.Liter},
                                                                   {"MILLILITER",          Units.Millilitre},  {"MILLILITRE",          Units.Millilitre},   {"MILLILITERS",    Units.Millilitre},   {"MILLILITRES",         Units.Millilitre},                                                                  
                                                                   {"PINT",                Units.PintUsLiquid},{"PINTS",               Units.PintUsLiquid},
                                                                   {"QUART",               Units.QuartUsLiquid},{"QUARTS",              Units.QuartUsLiquid},                                                                   
                                                                   {"TABLESPOON",          Units.Tablespoon},  {"TABLESPOONS",         Units.Tablespoon},
                                                                   {"TEASPOON",            Units.Teaspoon},    {"TEASPOONS",           Units.Teaspoon},
                                                                   
                                                                   //WEIGHT
                                                                   {"MILLIGRAM",           Units.Milligram},   {"MILLIGRAMS",          Units.Milligram},    {"MILLIGRAMME",    Units.Milligram},  {"MILLIGRAMMES",          Units.Milligram},
                                                                   {"GRAM",                Units.Gram},        {"GRAMS",               Units.Gram},         {"GRAMME",         Units.Gram},       {"GRAMMES",                Units.Gram},
                                                                   {"KILOGRAM",            Units.Kilogram},    {"KILOGRAMS",           Units.Kilogram},     {"KILOGRAMME",     Units.Kilogram},   {"KILOGRAMMES",           Units.Kilogram},                                                                   
                                                                   {"CARAT",               Units.Carat},       {"CARATS",              Units.Carat},
                                                                   {"POUND",               Units.Pound},       {"POUNDS",              Units.Pound},
                                                                   {"TONNE",               Units.Tonne},       {"TON",                 Units.Tonne},
                                                                   {"OUNCE",               Units.Ounce},       {"OUNCES",              Units.Ounce},
                                                                  

                                                                   
                                                                   
                                                               };
        
     
        public  Unit GetUnits(string inputString)
        {
            Unit unit = new Unit {result=0,measurement = 0, fromUnit = Units.Unknown, toUnit = Units.Unknown};
            string conversionString = inputString.ToUpper();
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string[] tokens = conversionString.Split(delimiterChars);
            unit.measurement = GetMeasurmentFromString(tokens[0]);

            //5 SQUARE FEET TO SQUARE YARDS
            //5 ACRES TO SQUARE FEET
            //5 SQUARE FEET TO ACRES            
            //5 ACREES TO HECTARES
            string fromStr = "";
            string toStr="";
            
            int indexOfToStr = Array.IndexOf<string>(tokens, "TO");

            for (int i = 1; i < indexOfToStr; i++)
            {
                if (fromStr != "")
                    fromStr += " ";
                fromStr += tokens[i];
            }
             for (int i = indexOfToStr+1; i < tokens.Length; i++)
            {
                if (toStr != "")
                    toStr += " ";
                toStr += tokens[i];
            }

          





            unit.fromUnit = GetUnitFromString(fromStr);
            unit.toUnit = GetUnitFromString(toStr);
            unit.result = GetResult(unit);
            return unit;
        }

       

        public Units GetUnitFromString(string tokenString)
        {
            Units units;
            if (unitDictionary.ContainsKey(tokenString))
                units = unitDictionary[tokenString];
            else 
                units = Units.Unknown;            
            return units;
        }

        public float GetMeasurmentFromString(string tokenString)
        {
            float measure = 0f;
            bool success = float.TryParse(tokenString,out measure);
            return measure;
        }

        public float GetResult(Unit unit)
        {
            Calculator calc= new Calculator();
            float result=calc.convertUnit(unit);
            return result;
        }
     

    }



    
    

