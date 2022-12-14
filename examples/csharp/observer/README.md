# Observer

## Example usage

**Main.cs**
```csharp src\Main.cs
using Observer;

ISubject subject = new Subject();
IObserver observerA = new ObserverA();
IObserver observerB = new ObserverB();
IObserver observerC = new ObserverC();

subject.RegisterObserver(observerA);
subject.RegisterObserver(observerB);
subject.RegisterObserver(observerC);

Customers customers = new Customers();
customers.Add(new Customer { ID = 1, Name = "Paul Nala", Salery = 35615.23m });
customers.Add(new Customer { ID = 2, Name = "Jones Smith", Salery = 60123 });
customers.Add(new Customer { ID = 3, Name = "Quinn Hills", Salery = 48693.50m });

subject.NotifyObservers(customers);

customers.Add(new Customer { ID = 4, Name = "Paula Schmidt", Salery = 63003.10m });

subject.NotifyObservers(customers);
```

**Console output**
```console
Output from ObserverA
Name: Paul Nala, Salery: 35615,23
Name: Jones Smith, Salery: 60123
Name: Quinn Hills, Salery: 48693,50

Output from ObserverB
Customer with highest salery: Jones Smith

Output from ObserverC
Number of customers: 3

Output from ObserverA
Name: Paul Nala, Salery: 35615,23
Name: Jones Smith, Salery: 60123
Name: Quinn Hills, Salery: 48693,50
Name: Paula Schmidt, Salery: 63003,10

Output from ObserverB
Customer with highest salery: Paula Schmidt

Output from ObserverC
Number of customers: 4
```

## Customer

**Customer.cs**
```csharp src\Customer.cs
namespace Observer
{
    internal class Customer
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal Salery { get; set; }
    }

    internal class Customers: List<Customer> { }
}
```

## Subject

**Subject.Intf.cs**
```csharp src\Subject.Intf.cs
namespace Observer
{
    internal interface ISubject
    {
        public void RegisterObserver(IObserver observer);

        public void UnregisterObserver(IObserver observer);

        public void NotifyObservers(Customers customers);
    }
}
```

**Subject.Impl.cs**
```csharp src\Subject.Impl.cs
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
```

## Observer

**Observer.Intf.cs**
```csharp src\Observer.Intf.cs
namespace Observer
{
    internal interface IObserver
    {
        void Update(Customers customers);
    }
}
```

**Observer.Impl.A.cs**
```csharp src\Observer.Impl.A.cs
namespace Observer
{
    internal class ObserverA : IObserver
    {
        public void Update(Customers customers)
        {
            Console.WriteLine("Output from ObserverA");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Name: {customer.Name}, Salery: {customer.Salery}");
            }
            Console.WriteLine();
        }
    }
}
```

**Observer.Impl.B.cs**
```csharp src\Observer.Impl.B.cs
using System.Collections.Generic;

namespace Observer
{
    internal class ObserverB : IObserver
    {
        public void Update(Customers customers)
        {
            Console.WriteLine("Output from ObserverB");

            var customer = customers.MaxBy(x => x.Salery);

            if (customer is not null)
            {
                Console.WriteLine($"Customer with highest salery: {customer.Name}");
            }

            Console.WriteLine();
        }
    }
}
```

**Observer.Impl.C.cs**
```csharp src\Observer.Impl.C.cs
namespace Observer
{
    internal class ObserverC : IObserver
    {
        public void Update(Customers customers)
        {
            Console.WriteLine("Output from ObserverC");
            Console.WriteLine($"Number of customers: {customers.Count}");
            Console.WriteLine();
        }        
    }
}
```