# Adapter

## Example usage

**Main.cs**
```csharp src\Main.cs
using Adapter;

var weatherZipcode = new WeatherZipcode();
var weaterAdapter = new WeatherAdapter(weatherZipcode);

string[] cities = { "Berlin", "Rom", "South Greensburg" };

foreach (var city in cities)
{
    double temperature = weaterAdapter.GetTemperatureByCity(city);
    Console.WriteLine($"Temperatur of {city}: {temperature.ToString()}");
}
```

**Console output**
```console
DEBUG WeatherAdapter.GetTemperatureByCity: city name: Berlin
DEBUG WeatherAdapter.CityNameToZipcode: Convert Berlin to zipcode
DEBUG WeatherZipcode.GetTemperatureByZipcode: Get temperature of zipcode 7404
Temperatur of Berlin: 15
DEBUG WeatherAdapter.GetTemperatureByCity: city name: Rom
DEBUG WeatherAdapter.CityNameToZipcode: Convert Rom to zipcode
DEBUG WeatherZipcode.GetTemperatureByZipcode: Get temperature of zipcode 3702
Temperatur of Rom: 12
DEBUG WeatherAdapter.GetTemperatureByCity: city name: South Greensburg
DEBUG WeatherAdapter.CityNameToZipcode: Convert South Greensburg to zipcode
DEBUG WeatherZipcode.GetTemperatureByZipcode: Get temperature of zipcode 19744
Temperatur of South Greensburg: 25
```

## Client interface

**WeatherCity.Intf.cs**
```csharp src\WeatherCity.Intf.cs
namespace Adapter
{
    internal interface IWeatherCity
    {
        public double GetTemperatureByCity(string cityName);
    }
}
```

## Adaptee

**WeatherZipcode.cs**
```csharp src\WeatherZipcode.cs
namespace Adapter
{
    internal class WeatherZipcode
    {
        public double GetTemperatureByZipcode(string zipcode)
        {
            Console.WriteLine("DEBUG WeatherZipcode.GetTemperatureByZipcode: Get " +
                             $"temperature of zipcode {zipcode}");            
            double temperature = 0;
            for (int i = 0; i < zipcode.Length; i++)
            {
                if (Char.IsDigit(zipcode[i]))
                    temperature += int.Parse(zipcode[i].ToString());
            }
            return temperature;
        }
    }
}
```

## Adapter

**WeatherAdapter.cs**
```csharp src\WeatherAdapter.cs
namespace Adapter
{
    internal class WeatherAdapter : IWeatherCity
    {
        private readonly WeatherZipcode _weatherZipCode;
        public WeatherAdapter(WeatherZipcode weatherZipCode)
        {
            this._weatherZipCode = weatherZipCode;
        }
     
        private string CityNameToZipcode(string cityName)
        {
            Console.WriteLine("DEBUG WeatherAdapter.CityNameToZipcode: " +
                             $"Convert {cityName} to zipcode");
            return (cityName.Length * 1234).ToString();
        }
        public double GetTemperatureByCity(string cityName)
        {
            Console.WriteLine("DEBUG WeatherAdapter.GetTemperatureByCity: " +
                             $"city name: {cityName}");
            return _weatherZipCode.GetTemperatureByZipcode(CityNameToZipcode(cityName));
        }
    }
}
```