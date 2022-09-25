# Abstract factory

## Example usage

**main.py**
```python src\main.py
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
```

**Console output**
```console
Mean value: 2.5
Total value: 10
```

## Factory

**factory.py**
```python src\factory.py
from abc import ABC, abstractmethod

class CalculationUnitFactory(ABC):

    @abstractmethod
    def create_calculation_unit(self):
        pass

    @abstractmethod
    def create_viewer(self):
        pass
```

**factory_totalizer.py**
```python src\factory_totalizer.py
from factory import CalculationUnitFactory
from calculation_unit_totalizer import CalculationUnitTotalizer
from viewer_total import ViewerTotal

class CalculationUnitFactoryTotalizer(CalculationUnitFactory):
    def create_calculation_unit(self):
        return CalculationUnitTotalizer()

    def create_viewer(self):
        return ViewerTotal()
```

**factory_mediator.py**
```python src\factory_mediator.py
from factory import CalculationUnitFactory
from calculation_unit_mediator import CalculationUnitMediator
from viewer_mean import ViewerMean

class CalculationUnitFactoryMediator(CalculationUnitFactory):
    def create_calculation_unit(self):
        return CalculationUnitMediator()

    def create_viewer(self):
        return ViewerMean()
```

## Interfaces & Classes

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

**viewer.py**
```python src\viewer.py
from abc import ABC, abstractmethod

class Viewer(ABC):

    @abstractmethod
    def get_output_string(self, value):
        pass
```

**viewer_total.py**
```python src\viewer_total.py
from viewer import Viewer

class ViewerTotal(Viewer):

    def get_output_string(self, value):
        return "Total value: {}".format(value)
```

**viewer_mean.py**
```python src\viewer_mean.py
from viewer import Viewer

class ViewerMean(Viewer):

    def get_output_string(self, value):
        return "Mean value: {}".format(value)
```