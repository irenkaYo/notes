namespace NotesBackend;

public class NotesService
{
    private List<Note> _notes;

    public NotesService()
    {
        _notes = new List<Note>();
    }
    
    public Note CreateNote(string title, string content)
    {
        Note note = new Note(title, content);
        _notes.Add(note);
        return note;
    }

    public IReadOnlyList<Note> GetNotes()
    {
        return _notes;
    }
    public Note GetNoteById(Guid id)
    {
        foreach (var note in _notes)
        {
            if  (note.Id == id)
                return note;
        }
        throw new Exception("Note not found");
    }

    public void DeleteNoteById(Guid id)
    {
        try
        {
            Note note = GetNoteById(id);
            _notes.Remove(note);
        }
        catch 
        {
            throw new Exception("Note not found");
        }
    }
}