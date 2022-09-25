using Adapter;

var weatherZipcode = new WeatherZipcode();
var weaterAdapter = new WeatherAdapter(weatherZipcode);

string[] cities = { "Berlin", "Rom", "South Greensburg" };

foreach (var city in cities)
{
    double temperature = weaterAdapter.GetTemperatureByCity(city);
    Console.WriteLine($"Temperatur of {city}: {temperature.ToString()}");
}