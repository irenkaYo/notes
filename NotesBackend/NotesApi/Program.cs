using NotesApi;
using NotesBackend;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var service = new NotesService();
app.MapPost("create_note", (CreateNoteDto createNote) =>
{
    Note note = service.CreateNote(createNote.Title, createNote.Content);
    NoteResponseDto response = new NoteResponseDto(note.Id, note.Title, note.Content);
    return response;
});

app.MapGet("get_all_notes", () =>
{
    //poka nepon List<NoteResponseDto> откуда это 
    IReadOnlyList<Note> notes = service.GetNotes();
    
    var result = notes.Select(x => new NoteResponseDto(x.Id, x.Title, x.Content)).ToList();
    return result;
    
});
//дальшне не смотреть, я не сделала 
app.MapGet("get_note/{id:guid}", (Guid id) =>
{
    Note note = service.GetNoteById(id);

});

app.MapDelete("delete_note/{id:guid}", (Guid id) =>
{
    service.DeleteNoteById(id);
    return "Note deleted";//а если нет
});

app.Run();