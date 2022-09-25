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
