public class Lecture : Event {
    private string _speaker;

    public Lecture(string title, string description, Address address, string date, string time, string speaker = ""):
    base(title, description, address, date, time){
        if(speaker != "")
            this._speaker = speaker;
        else
            this._speaker = "Not Disclosed";
    }

    public void SetSpeaker(string speaker){
        this._speaker = speaker;
    }

    override public string FullDetails(){
        string firstPart = base.FullDetails();
        return $"{firstPart} - Capacity: {this.GetCapacity()}\nSpeaker: {this._speaker}";

    }
}