# Singleton

## Example usage

**Main.cs**
```csharp src\Main.cs
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
```

**Console output**
```console
settings1 == settings2
Background color: Color [Black]
Text color: Color [Red]
```

## Class

**Settings.cs**
```csharp src\Settings.cs
using System.Drawing;

namespace Singleton
{
    internal sealed class Settings
    {
        private Settings() { }

        private static Settings? _instance;

        public static Settings GetInstance()
        {
            if (_instance is null)
            {
                _instance = new Settings();

                //Add example data
                _instance.BackgroundColor = Color.Black;
                _instance.TextColor = Color.Red;
            }
            return _instance;
        }

        public Color BackgroundColor { get; set; }

        public Color TextColor { get; set; }
    }
}
```