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
