using System;

public class Customer
{
    private string _name;
    private Address _address;

    public string Name {get {return _name; }}
    public Address Address {get {return _address;}}

    public Customer(string name, Address address)
    {
        this._name = name;
        this._address = address;
    }

    public bool IsUSACustomers()
    {
        return _address.IsUSACustomers();
    }
}