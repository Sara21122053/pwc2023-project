using System;

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("Jacket", 1, 21, 5);
        Product product2 = new Product("Phone", 2, 150, 1);
        Product product3 = new Product("Backpack", 3, 45, 3);

        Product product4 = new Product("Thermo", 4, 5.78, 2);
        Product product5 = new Product("Fruit cutter", 5, 2.25, 2);
        Product product6 = new Product("Coral gloves", 6, 3, 7);

        Address address1 = new Address("58 Los Cerezos street", "Montgomery", "Alabama", "USA");
        Customer customer1 = new Customer("Nina Brooks", address1);

        Address address2 = new Address("358 Sendo Green street", "Eastern Siberia", "Buryatia", "Russia");
        Customer customer2 = new Customer("Luisa Bulkova", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);

        string packagingLabel1 = order1.GetPackagingLabel();
        string shippingLabel1 = order1.GetShippingLabel();
        double totalPrice1 = order1.GetTotalPrice();

        string packagingLabel2 = order2.GetPackagingLabel();
        string shippingLabel2 = order2.GetShippingLabel();
        double totalPrice2 = order2.GetTotalPrice();

        Console.WriteLine("Packaging label order 1:");
        Console.WriteLine(packagingLabel1);
        Console.WriteLine();

        Console.WriteLine("Shipping label order 1:");
        Console.WriteLine(shippingLabel1);
        Console.WriteLine();

        Console.WriteLine("Total order price: $" + totalPrice1);
        Console.WriteLine();


        Console.WriteLine("Packaging label order 2:");
        Console.WriteLine(packagingLabel2);
        Console.WriteLine();

        Console.WriteLine("Shipping label order 2:");
        Console.WriteLine(shippingLabel2);
        Console.WriteLine();

        Console.WriteLine("Total order price: $" + totalPrice2);
    }
}
