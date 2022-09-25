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
