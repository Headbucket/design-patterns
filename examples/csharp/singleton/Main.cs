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