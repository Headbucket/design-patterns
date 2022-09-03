from calculation_unit import CalculationUnit
import statistics

class CalculationUnitMediator(CalculationUnit):

    def calculate(self, numbers):
        return statistics.mean(numbers)