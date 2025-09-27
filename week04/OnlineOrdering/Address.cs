public class Address
{
    private string _streetAddress;

    private string _city;

    private string _stateOrProvince;

    private string _country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool InUSA()
    {
        //in USA
        if (_country.ToLower() == "usa" || _country.ToLower() == "united states" || _country.ToLower() == "united states of america")
        {
            return true;
        }

        //not in USA
        else
        {
            return false;
        }
    }

    public string GetText()
    {
        return $"{_streetAddress}\n{_city}\n{_stateOrProvince}\n{_country}";
    }
}









// Address
// ----------
// * _streetAddress : string
// * _city : string
// * _stateOrProvince : string
// * _country : string
// ----------
// * Address(streetAddress : string, city : stateOrProvince : string, country : string)
// ----------
// * InUSA : bool
// * GetText : string