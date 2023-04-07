using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateItemDto
    {
        [StringLength(30, MinimumLength = 1)]
        public string? Name { get; init; }

        [RegularExpression("^(top|left|right|center|bottom)$")]
        public string? Position { get; init; }

        public string? Text { get; init; }

        [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string? Color { get; init; }

        public string? Parameter { get; init; }
    }
}