using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Dtos;
using Catalog.Entities;
namespace Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            return repository.GetItems().Select(item => item.AsDto());
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto>? GetItem(Guid id)
        {
            var item = repository.GetItem(id);

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

            repository.AddItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }
    }
}
