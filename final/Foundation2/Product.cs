using System;

public class Product
{
    private string _name;
    private int _id;
    private double _price;
    private int _quantity;

    public string Name {get {return _name; }}
    public int Id {get {return _id; }}
    public double Price {get {return _price; }}
    public int Quantity {get {return _quantity;}}

    public Product(string name, int id, double price, int quantity)
    {
        this._name = name;
        this._id = id;
        this._price = price;
        this._quantity = quantity;
    }

    public double GetPrice()
    {
        return _price * _quantity;
    }
}