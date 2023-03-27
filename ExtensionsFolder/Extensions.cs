using SwordShop.Dtos;
using SwordShop.Entities;

namespace SwordShop.ExtensionsFolder
{
    public static class Extensions
    {
       
            public static ItemDtos AsDto(this Items item)
            {
                return new ItemDtos
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    CreatedDate = item.CreatedDate
                };  
            }
        
    }
}
