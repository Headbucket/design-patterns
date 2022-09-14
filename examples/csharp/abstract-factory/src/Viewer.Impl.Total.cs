namespace AbstractFactory
{
    internal class ViewerTotal: IViewer
    {
        public string GetOutputString(double x)
        {
            return $"Total value: {x}";
        }
    }
}
