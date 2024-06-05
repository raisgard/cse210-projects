public class Address{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string city, string state, string country){
        this._streetAddress = streetAddress;
        this._city = city;
        this._state = state;
        this._country = country;
    }

    public string GetAddress(){
        return $"{this._streetAddress}, {this._city}, {this._state}, {this._country}";
    }

    public bool LivesInUSA(){
        if(this._country.ToLower() == "usa"){return true;}
        return false;
    }
    public string GetStreetAddress(){
        return this._streetAddress;
    }
    public string GetCity(){
        return this._city;
    }
    public string GetState(){
        return this._state;
    }
    public string GetCountry(){
        return this._country;
    }

}