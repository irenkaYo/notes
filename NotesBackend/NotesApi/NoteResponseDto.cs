namespace NotesApi;

public class NoteResponseDto
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    
    public NoteResponseDto(Guid id, string title, string content)
    {
        Id = id;
        Title = title;
        Content = content;
    }
}