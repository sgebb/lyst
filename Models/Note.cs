namespace Lyst.Models;

internal class Note
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTimeOffset Date { get; set; }
    public bool Checked { get; set; } = true;
}