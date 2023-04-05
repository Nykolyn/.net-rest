namespace Catalog.Entities
{
    public class Item
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }

         private static readonly DateTimeOffset DefaultCreatedDate = DateTimeOffset.UtcNow;

        public Item( string name, decimal price, DateTimeOffset? createdDate = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            CreatedDate = createdDate ?? DefaultCreatedDate;
        }
    }
}