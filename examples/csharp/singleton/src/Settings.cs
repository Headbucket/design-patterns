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
