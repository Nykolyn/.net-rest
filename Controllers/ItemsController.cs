using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Dtos;
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
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = await repository.GetItemsAsync();
            return items.Select(item => item.AsDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>>? GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new Item(Id: Guid.NewGuid(), Name: itemDto.Name, Text: itemDto.Text, Parameter: itemDto.Parameter, Color: itemDto.Color, Position: itemDto.Position);

            repository.AddItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ItemDto>> UpdateItemAsync(Guid id, UpdateItemDto patchDoc)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            var itemDto = new UpdateItemDto()
            {
                Name = existingItem.Name,
                Position = existingItem.Position,
                Parameter = existingItem.Parameter,
                Text = existingItem.Text,
                Color = existingItem.Color
            };

            if (!TryValidateModel(itemDto))
            {
                return BadRequest(ModelState);
            }

            var updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Position = itemDto.Position,
                Parameter = itemDto.Parameter,
                Text = itemDto.Text,
                Color = itemDto.Color
            };

            await repository.UpdateItemAsync(updatedItem);

            return updatedItem.AsDto();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItemAsync(Guid id)
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
