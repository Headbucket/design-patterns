unit CalculationUnit.Impl.Mediator;

interface

uses
  CalculationUnit.Intf;

type
  TCalculationUnitMediator = class(TInterfacedObject, ICalibrationUnit)
  public
    function Calculate(AList: TArray<integer>): double;
  end;

implementation

{ TCalculationUnitMediator }

function TCalculationUnitMediator.Calculate(AList: TArray<integer>): double;
var
  i: integer;
begin
  Result := 0;
  for i := Low(AList) to High(AList) do
    Result := Result + AList[i];
  if length(AList) > 0 then
    Result := Result / length(AList);
end;

end.
