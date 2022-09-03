from enum import Enum
from calculation_unit_totalizer import CalculationUnitTotalizer
from calculation_unit_mediator import CalculationUnitMediator

class CalculationUnitTypes(Enum):
    totalizer = 0
    mediator = 1

def create_calculation_unit(calculation_unit_type):
    if calculation_unit_type == CalculationUnitTypes.totalizer:
        return CalculationUnitTotalizer()
    elif calculation_unit_type == CalculationUnitTypes.mediator:
        return CalculationUnitMediator()
    else:
        raise Exception('Calculation unit type not implemented.')