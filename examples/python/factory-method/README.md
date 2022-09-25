# Factory method

## Example usage

**main.py**
```python src\main.py
from calculation_unit_factory import CalculationUnitTypes, create_calculation_unit

if __name__ == '__main__':
    list = [1, 2, 3, 4]

    unit1 = create_calculation_unit(CalculationUnitTypes.totalizer)    
    print(unit1.calculate(list))

    unit2 = create_calculation_unit(CalculationUnitTypes.mediator)  
    print(unit2.calculate(list)) 
```

**Console output**
```console
10
2.5
```

## Factory

**calculation_unit_factory.py**
```python src\calculation_unit_factory.py
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
```

## Interface & Classes

**calculation_unit.py**
```python src\calculation_unit.py
from abc import ABC, abstractmethod

class CalculationUnit(ABC):

    @abstractmethod
    def calculate(self, numbers):
        pass
```

**calculation_unit_totalizer.py**
```python src\calculation_unit_totalizer.py
from calculation_unit import CalculationUnit

class CalculationUnitTotalizer(CalculationUnit):

    def calculate(self, numbers):
        return sum(numbers)
```

**calculation_unit_mediator.py**
```python src\calculation_unit_mediator.py
from calculation_unit import CalculationUnit
import statistics

class CalculationUnitMediator(CalculationUnit):

    def calculate(self, numbers):
        return statistics.mean(numbers)
```