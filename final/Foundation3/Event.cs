public class Event {
    private string _title;
    private string _description;
    private Address _address;
    private string _date;
    private string _time;
    private int _capacity;

    public Event(string title, string description, Address address, string date, string time){
        this._title = title;
        this._description = description;
        this._address = address;
        this._date = date;
        this._time = time;
        this._capacity = 200;
    }

    public string StandardDetails(){
        return $"{this._title}\n{this._description}\n{this._date} - {this._time}\n{this._address.GetAddress()}";
    }

    protected string ClassType(){
        Type classType = this.GetType();
        return $"{classType}";
    }
    public void SetCapacity(int capacity){
        this._capacity = capacity;
    }
    public int GetCapacity(){
        return this._capacity;
    }

    virtual public string FullDetails(){
        return $"{this.StandardDetails()}\nEvent Type:{this.ClassType()}";
    }
    public string ShortDescription(){
        return ($"{ClassType()} - {this._title} - Date: {this._date} ");
    }
}