using Catalog.Dtos;

namespace Catalog
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Text = item.Text,
                Parameter = item.Parameter,
                Color = item.Color,
                Position = item.Position,
                CreatedDate = item.CreatedDate
            };
        }
    }
}