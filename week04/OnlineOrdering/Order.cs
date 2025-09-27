using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

public class Order
{
    private Customer _customer;

    private List<Product> _products;

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public double CalculateCost()
    {
        //product cost
        double totalCost = 0;
        foreach (Product product in _products)
        {
            totalCost += product.CalculateCost();
        }

        //shipping cost
        if (_customer.InUSA() == true)
        {
            totalCost += 5;
        }
        else
        {
            totalCost += 35;
        }

        //return
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string returnText = "";

        //get each products ID and name
        foreach (Product product in _products)
        {
            returnText += "\n" + product.GetPackingLabel();
        }

        //return
        return returnText;
    }

    public string GetShippingLabel()
    {
        return _customer.GetText();
    }
}









// Order
// ----------
// * _customer : Customer
// * _products : List<Products>
// ----------
// * Order(customer : Customer, products : List<Products>)
// ----------
// * CalculateCost : double
// * GetPackingLabel : string
// * GetShippingLabel : string