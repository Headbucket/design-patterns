# Factory method

## Example usage

**FactoryMethod.dpr**
```delphi src\FactoryMethod.dpr
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
```

**Console output**
```console
10
2,5
```

## Factory

**CalculationUnit.Factory.pas**
```delphi src\CalculationUnit.Factory.pas
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
```

## Interface & Classes

**CalculationUnit.Intf.pas**
```delphi src\CalculationUnit.Factory.pas
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
```

**CalculationUnit.Impl.Totalizer.pas**
```delphi src\CalculationUnit.Impl.Totalizer.pas
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
```

**CalculationUnit.Impl.Mediator.pas**
```delphi src\CalculationUnit.Impl.Mediator.pas
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
```