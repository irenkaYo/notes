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
    IReadOnlyList<Note> notes = service.GetNotes();
    List<NoteResponseDto> result = new List<NoteResponseDto>();
    foreach (Note note in notes)
    {
        result.Add(new NoteResponseDto(note.Id, note.Title, note.Content));
    }
    return result;
});

app.MapGet("get_note/{id:guid}", (Guid id) =>
{
    try
    {
        Note note = service.GetNoteById(id);
        return Results.Ok(new NoteResponseDto(note.Id, note.Title, note.Content));
    }
    catch
    {
        return Results.NotFound();
    }
});

app.MapDelete("delete_note/{id:guid}", (Guid id) =>
{
    try
    {
        service.DeleteNoteById(id);
        return Results.Ok();
    }
    catch
    {
        return Results.NotFound();
    }
});

app.Run();