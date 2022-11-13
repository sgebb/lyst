namespace Lyst.Views;

public partial class AllConversationsPage : ContentPage
{
    public AllConversationsPage()
    {
        InitializeComponent();

        BindingContext = new Models.AllConversations();
    }

    protected override void OnAppearing()
    {
        ((Models.AllConversations)BindingContext).LoadConversations();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AllNotesPage));
    }

    private async void conversationCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var conversation = (Models.Conversation)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.lyst.txt"
            await Shell.Current.GoToAsync($"{nameof(AllNotesPage)}?{nameof(AllNotesPage.ConversationId)}={conversation.Name}");

            // Unselect the UI
            conversationCollection.SelectedItem = null;
        }
    }
}