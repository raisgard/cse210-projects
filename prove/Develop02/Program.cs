public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response)
    {
        entries.Add(new Entry(prompt, response, DateTime.Now.ToString("dd/MM/yyyy")));
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("There are no entries in your journal yet.");
            return;
        }

        foreach (Entry entry in entries)
        {
            Console.WriteLine($"**Prompt:** {entry.Prompt}");
            Console.WriteLine($"**Response:** {entry.Response}");
            Console.WriteLine($"**Date:** {entry.Date}");
            Console.WriteLine("----------");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Prompt|Response|Date"); // Header row
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Prompt}|{entry.Response}|{entry.Date}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear(); // Clear existing entries
        using (StreamReader reader = new StreamReader(filename))
        {
            reader.ReadLine(); // Skip header row
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
        }
    }
}

public class Program
{
    static string[] prompts = new string[]
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What challenge did I overcome today?",
        "What am I grateful for today?",
        "What could I have done better today?"
    };

    static void Main(string[] args)
    {
        Journal journal = new Journal();
        int choice;

        do
        {
            Console.WriteLine("\nWelcome to Journal");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    WriteNewEntry(journal);
                    break;
                case 2:
                    journal.DisplayEntries();
                    break;
                case 3:
                    SaveToFile(journal);
                    break;
                case 4:
                    LoadFromFile(journal);
                    break;
            }

        } while (choice != 5);
    }

    static void WriteNewEntry(Journal journal)
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        journal.AddEntry(prompt, response);
        Console.WriteLine("Entry saved successfully!");
    }

    static void SaveToFile(Journal journal)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved to file!");
    }

    static void LoadFromFile(Journal journal)
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded from file!");
    }
}