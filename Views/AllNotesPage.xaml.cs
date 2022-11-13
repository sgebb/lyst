using Lyst.Models;

namespace Lyst.Views;

[QueryProperty(nameof(ConversationId), nameof(ConversationId))]
public partial class AllNotesPage : ContentPage
{
    public string ConversationId
    {
        set { LoadConversation(value); }
    }

    public AllNotesPage()
    {
        InitializeComponent();

        BindingContext = new Models.AllNotes
        {
            ConversationId = ""
        };
    }

    protected override void OnAppearing()
    {
    }

    private void LoadConversation(string conversationId)
    {
        //Models.Note noteModel = new Models.Note();
        //noteModel.Filename = fileName;

        //if (File.Exists(fileName))
        //{
        //    noteModel.Date = File.GetCreationTime(fileName);
        //    noteModel.Text = File.ReadAllText(fileName);
        //}

        //BindingContext = noteModel;

        ((Models.AllNotes)BindingContext).LoadNotes(conversationId);
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void OnEntryCompleted(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
        if (!string.IsNullOrEmpty(text))
        {
            ((AllNotes)BindingContext).AddNote(new Note
            {
                Text = text,
                Date = DateTime.Now,
            });

            ((Entry)sender).Text = "";
        }
    }
}