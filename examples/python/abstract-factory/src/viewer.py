from abc import ABC, abstractmethod

class Viewer(ABC):

    @abstractmethod
    def get_output_string(self, value):
        pass