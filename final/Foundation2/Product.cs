public class Product{
    private string _name;
    private string _id;
    private double _price;
    private int _quantity;

    public Product(string name, string id, double price, int quantity){
        this._name = name;
        this._id = id;
        this._price = price;
        this._quantity = quantity;
    }

    public double GetPrice(){
        return this._price * this._quantity;
    }
    public string GetName(){
        return this._name;
    }
    public string GetID(){
        return this._id;
    }
    public int GetQuantity(){
        return this._quantity;
    }
}