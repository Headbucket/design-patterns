namespace Observer
{
    internal class Subject : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();        

        public void RegisterObserver(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void UnregisterObserver(IObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void NotifyObservers(Customers customers)
        {
            foreach (var observer in _observers)
            {
                observer.Update(customers);
            }
        }
    }
}
