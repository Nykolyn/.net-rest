using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Dtos;
using Catalog.Entities;
namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

         public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            var items = await repository.GetItemsAsync();
            return items.Select(item => item.AsDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>>? GetItem(Guid id)
        {
            var item = await repository.GetItemAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new Item(Name: itemDto.Name, Price: itemDto.Price, Id: Guid.NewGuid());

            repository.AddItemAsync(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateItemDto itemDto)
        {

            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            await repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {

            var existingItem = repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}
