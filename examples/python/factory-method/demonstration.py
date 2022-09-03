from calculation_unit_factory import CalculationUnitTypes, create_calculation_unit

if __name__ == '__main__':
    list = [1, 2, 3, 4]

    unit1 = create_calculation_unit(CalculationUnitTypes.totalizer)    
    print(unit1.calculate(list))

    unit2 = create_calculation_unit(CalculationUnitTypes.mediator)  
    print(unit2.calculate(list)) 