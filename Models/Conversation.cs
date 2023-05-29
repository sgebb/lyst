using System.Collections.ObjectModel;

namespace Lyst.Models;

internal class Conversation
{
    public string Name { get; set; }

    public string Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}