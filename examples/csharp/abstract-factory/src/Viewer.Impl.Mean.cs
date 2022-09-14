namespace AbstractFactory
{
    internal class ViewerMean: IViewer
    {
        public string GetOutputString(double x)
        {
            return $"Mean value: {x}";
        }
    }
}
