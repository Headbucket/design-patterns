using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class CalculationUnitFactory
    {
        public enum CalculationUnitType
        {
            Totalizer,
            Mediator
        }
        public static ICalculationUnit CreateCalculationUnit(CalculationUnitType cuType)
        {
            switch(cuType)
            {
                case CalculationUnitType.Totalizer:
                    {
                        return new CalculationUnitTotalizer();                        
                    }
                case CalculationUnitType.Mediator:
                    {
                        return new CalculationUnitMediator();
                    }
                default:
                    {
                        throw new ArgumentException("Calculation unit type not implemented.");
                    }
            }
        }
    }
}
