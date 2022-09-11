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