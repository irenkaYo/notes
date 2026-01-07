using NoteFrontend;
using NotesApi;

class Program
{
    private static NoteApiHandler noteApiHandler;
    static void Main()
    {
        noteApiHandler = new NoteApiHandler("http://localhost:5050/");
        int choice = 0;
        while (choice != 5)
        {
            Task.Delay(1000).Wait();
            Console.WriteLine("1. Create note\n2. List notes\n3. View note\n4. Delete note\n5. Exit");
            Console.WriteLine("Enter number: ");
            choice = int.Parse(Console.ReadLine());
            DoChoice(choice);
        }
    }

    private async static void DoChoice(int choice)
    {
        switch (choice)
        {
            case 1:
            {
                Console.WriteLine("Enter note name: ");
                string title = Console.ReadLine(); 
                Console.WriteLine("Enter note description: ");
                string content = Console.ReadLine();
                var response = await noteApiHandler.CreateNoteAsync(title, content);
                Console.WriteLine("Note created successfully");
                DataOutput(response);
                break;
            }
            case 2:
            {
                var listResponse = await noteApiHandler.GetNotesAsync();
                foreach (var response in listResponse)
                {
                    DataOutput(response);
                }
                break;
            }
            case 3:
            {
                Guid noteId = InputId();
                var response = await noteApiHandler.GetNoteAsync(noteId);
                DataOutput(response);
                break;
            }
            case 4:
            {
                Guid noteId = InputId();
                var response = await noteApiHandler.DeleteNoteAsync(noteId);
                Console.WriteLine(response);
                break;
            }
            case 5:
            {
                Console.WriteLine("Exit");
                break;
            }
            default:
            {
                Console.WriteLine("Input error");
                break;
            }
        }
    }

    private static Guid InputId()
    {
        Console.WriteLine("Enter note ID: ");
        Guid noteId = Guid.Parse(Console.ReadLine());
        return noteId;
    }

    private static void DataOutput(NoteResponseDto response)
    {
        Console.WriteLine($"Id: {response.Id}\nTitle: {response.Title}\nContent: {response.Content}");
    }
}