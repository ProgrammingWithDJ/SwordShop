using System.ComponentModel.DataAnnotations;

namespace SwordShop.Dtos
{
    public class CreateItemDtos
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1,1000)]
        public decimal Price { get; init; }
    }
}
