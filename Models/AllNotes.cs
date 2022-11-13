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

        // Get the folder where the lyst are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.lyst.txt files.
        IEnumerable<Note> lyst = Directory

                                    // Select the file names from the directory
                                    .EnumerateFiles(appDataPath, "*.lyst.txt")

                                    // Each file name is used to create a new Note
                                    .Select(filename => new Note()
                                    {
                                        Filename = filename,
                                        Text = File.ReadAllText(filename),
                                        Date = File.GetCreationTime(filename)
                                    })

                                    // With the final collection of lyst, order them by date
                                    .OrderBy(note => note.Date);

        // Add each note into the ObservableCollection
        foreach (Note note in lyst)
            Notes.Add(note);
    }

    public void AddNote(Note note)
    {
        Notes.Add(note);

    }
}