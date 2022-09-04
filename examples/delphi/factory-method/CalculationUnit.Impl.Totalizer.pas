unit CalculationUnit.Impl.Totalizer;

interface

uses
  CalculationUnit.Intf;

type
  TCalculationUnitTotalizer = class(TInterfacedObject, ICalibrationUnit)
  public
    function Calculate(AList: TArray<integer>): double;
  end;

implementation

{ TCalculationUnitTotalizer }

function TCalculationUnitTotalizer.Calculate(AList: TArray<integer>): double;
var
  i: integer;
begin
  Result := 0;
  for i := Low(AList) to High(AList) do
    Result := Result + AList[i];
end;

end.
