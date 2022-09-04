namespace AbstractFactory
{
    internal class ViewerTotal: IViewer
    {
        public string GetOutputString(double x)
        {
            return String.Format("Total value: {0}", x);
        }
    }
}
