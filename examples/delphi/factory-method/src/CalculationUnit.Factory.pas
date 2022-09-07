unit CalculationUnit.Factory;

interface

uses
  System.SysUtils,
  CalculationUnit.Intf,
  CalculationUnit.Impl.Totalizer,
  CalculationUnit.Impl.Mediator;

type
  TCalculationUnitType = (cuTotalizer, cuMediator);

  TCalculationUnitFactory = class abstract
  public
    class function CreateCalculationUnit(ACalculationUnitType: TCalculationUnitType): ICalibrationUnit;
  end;

implementation

{ TCalculationUnitFactory }

class function TCalculationUnitFactory.CreateCalculationUnit(ACalculationUnitType: TCalculationUnitType): ICalibrationUnit;
begin
  case ACalculationUnitType of
    cuTotalizer: Result := TCalculationUnitTotalizer.Create();
    cuMediator: Result := TCalculationUnitMediator.Create();
    else raise Exception.Create('Calculation unit type not implemented.');
  end;
end;

end.
