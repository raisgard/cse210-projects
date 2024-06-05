public class Customer {

    private string _name;
    private Address _address;

    public Customer(string name, Address address){
        this._name = name;
        this._address = address;
    }
    public bool LiveInUSA(){
        return this._address.LivesInUSA();
    }
    public string GetName(){
        return this._name;
    }
    public string GetAddress(){
        return this._address.GetAddress();
    }

}