from factory_totalizer import CalculationUnitFactoryTotalizer
from factory_mediator import CalculationUnitFactoryMediator

if __name__ == '__main__':
    list = [1, 2, 3, 4]

    for i in range(2):
        if i == 0:
            factory = CalculationUnitFactoryMediator()
        else:
            factory = CalculationUnitFactoryTotalizer()
        unit = factory.create_calculation_unit()
        viewer = factory.create_viewer()
        print(viewer.get_output_string(unit.calculate(list)))