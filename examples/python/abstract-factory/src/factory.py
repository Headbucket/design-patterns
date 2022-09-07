from abc import ABC, abstractmethod

class CalculationUnitFactory(ABC):

    @abstractmethod
    def create_calculation_unit(self):
        pass

    @abstractmethod
    def create_viewer(self):
        pass