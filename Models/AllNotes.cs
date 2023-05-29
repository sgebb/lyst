using System.Collections.ObjectModel;

namespace Lyst.Models;

internal class AllNotes
{
    public string ConversationId { get; set; }
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

    public void LoadNotes(string conversationId)
    {
        ConversationId = conversationId;
        Notes.Clear();

        // Use Linq extensions to load the *.lyst.txt files.
        var notes = System.Text.Json.JsonSerializer.Deserialize<List<Note>>(File.ReadAllText(conversationId));

        // Add each note into the ObservableCollection
        foreach (var note in notes)
        {
            Notes.Add(note);
        }
    }

    public void AddNote(Note note)
    {
        Notes.Add(note);
        File.WriteAllText(ConversationId, System.Text.Json.JsonSerializer.Serialize(Notes));
    }

    public void ReverseCheck(int noteid)
    {
        var note = Notes.FirstOrDefault(n => n.Id == noteid);
        note.Checked =! note.Checked;
        File.WriteAllText(ConversationId, System.Text.Json.JsonSerializer.Serialize(Notes));
    }
}