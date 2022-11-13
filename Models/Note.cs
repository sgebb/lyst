namespace Lyst.Models;

internal class Note
{
    public string Filename { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public bool Checked { get; set; } = true;
}