public class Customer
{
    private string _name;

    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetText()
    {
        return $"{_name}\n{_address.GetText()}";
    }

    public bool InUSA()
    {
        return _address.InUSA();
    }
}