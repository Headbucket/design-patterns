# Singleton

## Example usage

**Main.cs**
```csharp src\Main.cs
using Singleton;
using System.Runtime.InteropServices;

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

Console.WriteLine(String.Format("Background color: {0}", settings1.BackgroundColor.ToString()));
Console.WriteLine(String.Format("Text color: {0}", settings1.TextColor.ToString()));
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
            if (_instance == null)
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