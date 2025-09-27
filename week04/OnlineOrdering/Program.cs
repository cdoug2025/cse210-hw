using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        //order1 setup
        List<Product> products1 = [
            new Product("Bread", 1337, 2.14, 5),
            new Product("Baseball", 3564, 1.36, 1),
            new Product("Celery", 2776, 0.15, 4),
            new Product("Corn", 1199, 1.99, 3),
        ];
        Address address1 = new("774 Second Street", "New York City", "New York", "USA");
        Customer Customer1 = new("Doug Jay", address1);
        Order order1 = new(Customer1, products1);

        //display order1
        Console.WriteLine($"Your shipping label is:\n{order1.GetShippingLabel()}");
        Console.WriteLine();
        Console.WriteLine($"Your packing label is: {order1.GetPackingLabel()}");
        Console.WriteLine();
        Console.WriteLine($"The total cost for your order is: {order1.CalculateCost()}");

        Console.WriteLine("\n");

        //order2 setup
        List<Product> products2 = [
            new Product("Bread", 1337, 2.14, 3),
            new Product("Milk", 1750, 5.12, 3),
            new Product("Pop Tarts", 1237, 4.97, 12),
        ];
        Address address2 = new("132 Glen Cir", "Arizona City", "Arizona", "USA");
        Customer Customer2 = new("Minnie Celeste", address2);
        Order order2 = new(Customer2, products2);

        //display order2
        Console.WriteLine($"Your shipping label is:\n{order2.GetShippingLabel()}");
        Console.WriteLine();
        Console.WriteLine($"Your packing label is: {order2.GetPackingLabel()}");
        Console.WriteLine();
        Console.WriteLine($"The total cost for your order is: {order2.CalculateCost()}");

        Console.WriteLine("\n");

        //order3 setup
        List<Product> products3 = [
            new Product("Pizza", 2361, 9.99, 5),
            new Product("Popcorn", 3827, 5.00, 1),
            new Product("Plates", 1076, 6.99, 2),
        ];
        Address address3 = new("Champs-Elysees", "Paris", "Ile-de-France", "France");
        Customer Customer3 = new("Gabriel Auclair", address3);
        Order order3 = new(Customer3, products3);

        //display order3
        Console.WriteLine($"Your shipping label is:\n{order3.GetShippingLabel()}");
        Console.WriteLine();
        Console.WriteLine($"Your packing label is: {order3.GetPackingLabel()}");
        Console.WriteLine();
        Console.WriteLine($"The total cost for your order is: {order3.CalculateCost()}");
    }
}