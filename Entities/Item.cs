using System.ComponentModel.DataAnnotations;

public record Item
{
    public Guid Id { get; init; }

    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string Name { get; set; }

    [Required]
    [RegularExpression("^(top|left|right|center|bottom)$")]
    public string Position { get; set; }

    public string? Parameter { get; set; }

    [Required]
    public string Text { get; set; }

    [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
    public string? Color { get; set; }

    public DateTimeOffset CreatedDate { get; init; }

    public Item(Guid Id, string Name, string Position, string Text, string? Color, string? Parameter)
    {
        this.Id = Id;
        this.Name = Name;
        this.Position = Position;
        this.Parameter = Parameter;
        this.Text = Text;
        this.Color = Color;
        this.CreatedDate = DateTimeOffset.UtcNow;
    }
}
