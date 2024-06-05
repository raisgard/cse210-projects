public class Activity {
    private string _date;
    private int _length;

    public Activity(string date, int length){
        this._date = date;
        this._length = length;
    }

    virtual public double GetDistance(){
        return 0;
    }
    virtual public double GetSpeed(){
        return (GetDistance() / this._length * 60);
    }
    virtual public double GetPace(){
        return this._length / GetDistance();
    }
    
    public int GetLength(){
        return this._length;
    }
    public string GetDate(){
        return this._date;
    }

    public string GetSummary(){
        Type classType = this.GetType();
        return $"{this._date} {classType} ({this._length})- Distance {Math.Round(this.GetDistance(), 2)} miles, Speed {Math.Round(this.GetSpeed(), 2)} mph, Pace: {Math.Round(this.GetPace(), 2)} min per mile";
    }
}