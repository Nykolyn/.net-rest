namespace Catalog.Entities
{
    public class Item
    {
        private Func<Guid> id;

        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }

        public Item(string Name, decimal Price, Guid Id)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.CreatedDate = DateTimeOffset.UtcNow;
        }
    }
}
