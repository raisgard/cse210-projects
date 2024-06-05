public class Cycling : Activity {
    private double _speed;

    public Cycling(string date, int length, double speed): base(date, length){
        this._speed = speed;
    }
    override public double GetDistance(){
        return this.GetLength() / GetPace();
    }
    override public double GetSpeed(){
        return this._speed;
    }
    override public double GetPace(){
        return 60 / GetSpeed();
    }
}