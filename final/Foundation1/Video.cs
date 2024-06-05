public class Video{
    private string _author;
    private string _title;
    private int _length;
    List<Comment> _commentList;
    
    public Video(string author, string title, int length, List<Comment> list){
        this._author = author;
        this._title = title;
        this._length = length;
        this._commentList = list;
    }

    public string GetAuthor(){
        return this._author;
    }
    public string GetTitle(){
        return this._title;
    }
    public int GetLength(){
        return this._length;
    }
    public void Display(){
        Console.WriteLine($"Video Title: {this._title}\nAuthor: {this._author} - Length: {this._length} seconds"+
        $"\nComments:{this._commentList.Count}");
    }
    public void DisplayComments(){
        Console.WriteLine("Comments ---");
        for(int i = 0; i < this._commentList.Count; i++){
            Console.WriteLine(this._commentList[i].GetComment());
        }
    }
    public int CommentsCount(){
        return this._commentList.Count;
    }

}