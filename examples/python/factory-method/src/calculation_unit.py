from abc import ABC, abstractmethod

class CalculationUnit(ABC):

    @abstractmethod
    def calculate(self, numbers):
        pass