public class Order {
    private List<Product> _productList;
    private Customer _customer;
    private double _shippingPrice;

    public Order(List<Product> productList, Customer customer){
        this._productList = productList;
        this._customer = customer;
        this._shippingPrice = SetShippingPrice();
    }

    public string PackingLabel(){
        string str = "";
        foreach(Product item in this._productList){
            str += ($"Name:{item.GetName()} - ID:{item.GetID()}\n");
        }
        return str;
    }
    public string ShippingLabel(){
        return $"{this._customer.GetName()}\n{this._customer.GetAddress()}";   
    }
    private double SetShippingPrice(){
        if(this._customer.LiveInUSA()){ return 5.00;}
        return 35.00;
    }
    public double CalcTotalPrice(){
        double price = 0;
        foreach(Product item in this._productList){
            price += item.GetPrice();
        }
        price += this._shippingPrice;
        return price;
    }
    public double GetShippingPrice(){
        return this._shippingPrice;
    }
}