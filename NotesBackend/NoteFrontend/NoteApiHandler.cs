using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using NotesApi;
namespace NoteFrontend;

public class NoteApiHandler
{
    private HttpClient httpClient;
    
    public NoteApiHandler(string baseUrl)
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);
    }

    public async Task<NoteResponseDto> CreateNoteAsync(string title, string content)
    {
        CreateNoteDto noteDto = new CreateNoteDto(title, content);
        var response = await httpClient.PostAsJsonAsync("create_note", noteDto);
        return await response.Content.ReadFromJsonAsync<NoteResponseDto>();
    }

    public async Task<List<NoteResponseDto>> GetNotesAsync()
    {
        var response = await httpClient.GetAsync("get_all_notes");
        return await response.Content.ReadFromJsonAsync<List<NoteResponseDto>>();
    }

    public async Task<NoteResponseDto> GetNoteAsync(Guid id)
    {
        var response = await httpClient.GetAsync($"get_note/{id}");
        return await response.Content.ReadFromJsonAsync<NoteResponseDto>();
    }
    
    public async Task<string> DeleteNoteAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"delete_note/{id}");
        return response.StatusCode.ToString();
    }
}
