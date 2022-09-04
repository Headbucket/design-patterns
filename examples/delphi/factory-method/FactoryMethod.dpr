program FactoryMethod;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils,
  CalculationUnit.Intf in 'CalculationUnit.Intf.pas',
  CalculationUnit.Impl.Mediator in 'CalculationUnit.Impl.Mediator.pas',
  CalculationUnit.Impl.Totalizer in 'CalculationUnit.Impl.Totalizer.pas',
  CalculationUnit.Factory in 'CalculationUnit.Factory.pas';

var
  List: TArray<integer>;
  Unit1: ICalibrationUnit;
  Unit2: ICalibrationUnit;

begin
  try
    List := [1, 2, 3, 4];

    Unit1 := TCalculationUnitFactory.CreateCalculationUnit(cuTotalizer);
    Writeln(Unit1.Calculate(List).ToString());

    Unit2 := TCalculationUnitFactory.CreateCalculationUnit(cuMediator);
    Writeln(Unit2.Calculate(List).ToString());

    Readln;
  except
    on E: Exception do
      Writeln(E.ClassName, ': ', E.Message);
  end;
end.
