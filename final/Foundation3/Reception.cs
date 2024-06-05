public class Reception : Event {

    public Reception(string title, string description, Address address, string date, string time):
    base(title, description, address, date, time){

    }

    override public string FullDetails(){
        string firstPart = base.FullDetails();
        return $"{firstPart} - Capacity: {this.GetCapacity()}\nPlease Remember to RSVP to the event!";

    }

}