using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        this._products = new List<Product>();
        this._customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;

        foreach (Product product in _products)
        {
            totalPrice += product.GetPrice();
        }

        if (_customer.IsUSACustomers())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
        }

        return totalPrice;
    }

    public string GetPackagingLabel()
    {
        string label = "";

        foreach (Product product in _products)
        {
            label += $"Product: {product.Name}, ID: {product.Id}\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"Customer: {_customer.Name}\nDirection: {_customer.Address.GetAddressString()}";
    }
}