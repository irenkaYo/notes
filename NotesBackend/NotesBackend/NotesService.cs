namespace NotesBackend;

public class NotesService
{
    private List<Note> notes;

    public NotesService()
    {
        notes = new List<Note>();
    }
    
    public void CreateNote(string title, string content)
    {
        Note note = new Note(title, content);
        notes.Add(note);
    }

    public List<Note> GetNotes()
    {
        return notes;
    }
    public Note GetNoteById(Guid id)
    {
        foreach (var note in notes)
        {
            if  (note.Id == id)
                return note;
        }
        throw new Exception("Note not found");
    }

    public void DeleteNoteById(Guid id)
    {
        foreach (var note in notes)
        {
            if (note.Id == id)
            {
                notes.Remove(note);
            } 
        }
        throw new Exception("Note not found");
    }
}