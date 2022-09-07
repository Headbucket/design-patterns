namespace AbstractFactory
{
    internal class ViewerMean: IViewer
    {
        public string GetOutputString(double x)
        {
            return String.Format("Mean value: {0}", x);
        }
    }
}
