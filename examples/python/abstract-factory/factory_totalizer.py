from factory import CalculationUnitFactory
from calculation_unit_totalizer import CalculationUnitTotalizer
from viewer_total import ViewerTotal

class CalculationUnitFactoryTotalizer(CalculationUnitFactory):
    def create_calculation_unit(self):
        return CalculationUnitTotalizer()

    def create_viewer(self):
        return ViewerTotal()