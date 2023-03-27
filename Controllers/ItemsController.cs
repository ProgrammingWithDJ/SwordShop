using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwordShop.Dtos;
using SwordShop.Entities;
using SwordShop.ExtensionsFolder;
using SwordShop.Repository;

namespace SwordShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items= repository.GetItems().Select(x =>x.AsDto());

            return Ok(items);
        }

        [HttpGet("{Id}")]   
        public IActionResult GetItems(Guid Id)
        {
            var item= repository.GetItem(Id);

            if(item is null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }


        [HttpPost]
        public IActionResult CreateItem(CreateItemDtos itemsdto)
        {
            Items item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemsdto.Name,
                Price = itemsdto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItems(item);

            return CreatedAtAction(nameof(GetItems), new {id =item.Id}, item.AsDto());
        }

        [HttpPut("{Id}")]
        public IActionResult updateItem(Guid Id, UpdateItemDto updateDto)
        {
            var existingItem= repository.GetItem(Id);

            if(existingItem is null)
            {
                return NotFound();
            }
           
                Items updatItem = new()
                {
                    Name = updateDto.Name,
                    Price = updateDto.Price
                };
           
            repository.UpdateItems(updatItem);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteItem(Guid Id)
        {
            var existingItem = repository.GetItem(Id);

            if (existingItem is null)
            {
                return NotFound();
            }

          

            repository.DeleteItems(Id);

            return NoContent();
        }
    
    }
}
