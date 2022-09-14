using Singleton;

Settings settings1 = Settings.GetInstance();
Settings settings2 = Settings.GetInstance();

if (settings1 == settings2)
{
    Console.WriteLine("settings1 == settings2");
}
else
{
    Console.WriteLine("settings1 != settings2");
}

Console.WriteLine($"Background color: {settings1.BackgroundColor}");
Console.WriteLine($"Text color: {settings1.TextColor}");