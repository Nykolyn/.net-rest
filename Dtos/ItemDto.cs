namespace Catalog.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string? Parameter { get; set; }
        public string Text { get; set; }
        public string? Color { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}