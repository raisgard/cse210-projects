using System;

class Program
{
    static void Main(string[] args)
    {
        Activity running = new Running("07 May 2023", 30, 3.0);
        Activity cycling = new Cycling("08 Mar 2023", 30, 6.0);
        Activity swimming = new Swimming("15 Dec 2022", 30, 96.75);

        Activity running2 = new Running("03 Nov 2022", 30, 4.8);
        Activity cycling2 = new Cycling("01 Jan 2023", 30, 9.7);
        Activity swimming2 = new Swimming("12 Feb 2023", 30, 63.75);


        List<Activity> activities = new List<Activity>{running, cycling, swimming,
        running2, cycling2, swimming2};
        foreach(Activity activity in activities){
            Console.WriteLine(activity.GetSummary() +"\n");
        }
    }
}