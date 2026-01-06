namespace NotesBackend;

public class Note
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }

    public Note(string title, string content)
    {
        Id = Guid.NewGuid();
        Title = title;
        Content = content;
    }
}