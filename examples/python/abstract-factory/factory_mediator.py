from factory import CalculationUnitFactory
from calculation_unit_mediator import CalculationUnitMediator
from viewer_mean import ViewerMean

class CalculationUnitFactoryMediator(CalculationUnitFactory):
    def create_calculation_unit(self):
        return CalculationUnitMediator()

    def create_viewer(self):
        return ViewerMean()