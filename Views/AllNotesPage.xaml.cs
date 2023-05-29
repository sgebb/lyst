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
        var allNotes = new AllNotes();
        allNotes.LoadNotes(conversationId);

        BindingContext = allNotes;
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
                Date = DateTimeOffset.Now,
                Checked = false
            });

            ((Entry)sender).Text = "";
        }
    }

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkbox = (CheckBox)sender;
        var note = (Note)checkbox.BindingContext;
        ((AllNotes)BindingContext).ReverseCheck(note.Id);
    }
}