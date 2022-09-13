namespace NullObject
{
    internal class Customer
    {
        public string? firstName { get; set; }

        public string? lastName { get; set; }
    }

    internal class Customers: List<Customer>
    { }
}
