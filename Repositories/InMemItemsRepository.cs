using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item (Name: "Potion", Price: 9, Id: Guid.NewGuid()),
            new Item (Name: "Iron Sword", Price: 20,  Id: Guid.NewGuid()),
            new Item (Name: "Bronze Shield", Price: 19, Id: Guid.NewGuid())
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item? GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void AddItem(Item item) {
           items.Add(item);
        }

        public void UpdateItem(Item item) {
           var index =  items.FindIndex(existingItem => existingItem.Id == item.Id);
           items[index] = item;
        }
    }
}