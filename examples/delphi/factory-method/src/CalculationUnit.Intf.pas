unit CalculationUnit.Intf;

interface

type
  ICalibrationUnit = interface
    ['{B26624AD-57C9-4DCD-93F0-696BA917EC62}']
    function Calculate(AList: TArray<integer>): double;
  end;

implementation

end.
