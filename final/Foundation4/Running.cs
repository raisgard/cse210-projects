public class Running : Activity {
    private double _distance;

    public Running(string date, int length, double distance): base(date, length){
        this._distance = distance;

    }
    override public double GetDistance(){
        return this._distance;
    }
}