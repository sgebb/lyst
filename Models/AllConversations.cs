using System.Collections.ObjectModel;

namespace Lyst.Models;

internal class AllConversations
{
    public ObservableCollection<Conversation> Conversations { get; set; } = new ObservableCollection<Conversation>();

    public AllConversations() =>
        LoadConversations();

    public void LoadConversations()
    {
        Conversations.Clear();

        // Get the folder where the lyst are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.lyst.txt files.
        IEnumerable<Conversation> conversations = Directory

                                    // Select the folder names from the directory
                                    .EnumerateFiles(appDataPath, "*.lyst.txt")

                                    // Each file name is used to create a new Conversation
                                    .Select(filename => new Conversation()
                                    {
                                        Id = filename,
                                        Name = filename,
                                        CreatedAt = File.GetCreationTimeUtc(filename),
                                        UpdatedAt = File.GetLastWriteTimeUtc(filename)
                                    })

                                    .OrderBy(note => note.UpdatedAt);

        foreach (var conversation in conversations)
            Conversations.Add(conversation);

    }
}