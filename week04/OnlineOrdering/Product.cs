public class Product
{
    private string _name;

    private int _id;

    private double _price;

    private int _quantity;

    public Product(string name, int id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    public double CalculateCost()
    {
        return _price * _quantity;
    }

    public string GetPackingLabel()
    {
        return $"{_id}, {_name}";
    }
}









// Product
// ----------
// * _name : string
// * _id : string or int
// * _price : double
// * _quantity : int
// ----------
// * Product(name : string, id : string or int, price : double, quantity : int)
// ----------
// * CalculateCost : double
// * GetPackingLabel : string