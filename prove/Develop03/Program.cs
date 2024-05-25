public class Scripture
{
    public ScriptureReference Reference { get; private set; }
    public List<Word> Text { get; private set; }

    public Scripture(ScriptureReference reference, string text)
    {
        this.Reference = reference;
        this.Text = SplitText(text);
    }

    private List<Word> SplitText(string text)
    {
        return text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numWords)
    {
        for (int i = 0; i < numWords; i++)
        {
            int randomIndex = new Random().Next(Text.Count);
            Text[randomIndex].IsHidden = true;
        }
    }

    public override string ToString()
    {
        return $"{Reference}\n{string.Join(" ", Text)}";
    }
}

public class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int? VerseStart { get; private set; }
    public int? VerseEnd { get; private set; }

    public ScriptureReference(string reference)
    {
        string[] parts = reference.Split(':');
        Book = parts[0];
        Chapter = int.Parse(parts[1].Split('-')[0]);

        if (parts.Length > 1)
        {
            string[] verseRange = parts[1].Split('-');
            VerseStart = int.Parse(verseRange[0]);
            if (verseRange.Length > 1)
            {
                VerseEnd = int.Parse(verseRange[1]);
            }
        }
    }

    public override string ToString()
    {
        if (VerseStart != null && VerseEnd != null)
        {
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        }
        else if (VerseStart != null)
        {
            return $"{Book} {Chapter}:{VerseStart}";
        }
        else
        {
            return $"{Book} {Chapter}";
        }
    }
}

public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public override string ToString()
    {
        return IsHidden ? "[...]" : Text;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Scripture Reference (e.g., John 3:16 or Proverbs 3:5-6):");
        string referenceString = Console.ReadLine();
        Console.WriteLine("Enter Scripture Text:");
        string scriptureText = Console.ReadLine();

        Scripture scripture = new Scripture(new ScriptureReference(referenceString), scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture);

            Console.WriteLine("\nPress Enter to continue, or type 'quit' to finish:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }
            else
            {
                scripture.HideRandomWords(3); // Change 3 to desired number of words to hide
            }
        }
    }
}
