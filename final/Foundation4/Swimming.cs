public class Swimming : Activity {
    private double _laps;

    public Swimming(string date, int length, double laps): base(date, length){
        this._laps = laps;
    }
    override public double GetDistance(){
        return this._laps * 50 / 1000 * 0.62;
    }
}