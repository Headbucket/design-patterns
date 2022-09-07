from calculation_unit import CalculationUnit

class CalculationUnitTotalizer(CalculationUnit):

    def calculate(self, numbers):
        return sum(numbers)