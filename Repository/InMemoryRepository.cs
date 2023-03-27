using Microsoft.AspNetCore.Mvc;
using SwordShop.Entities;

namespace SwordShop.Repository
{
    public class InMemoryRepository : IItemsRepository
    {

        private readonly List<Items> items = new()
        {
            new Items { Id=Guid.NewGuid(), Name="Portion", Price=9, CreatedDate=DateTimeOffset.UtcNow},
            new Items { Id=Guid.NewGuid(), Name="Sword", Price=6, CreatedDate=DateTimeOffset.UtcNow},
            new Items { Id=Guid.NewGuid(), Name="Shiled", Price=20, CreatedDate=DateTimeOffset.UtcNow}
        };

        public IEnumerable<Items> GetItems()
        {
            return items;
        }

        public Items GetItem(Guid Id)
        {
            var itemss = items.Where(x => x.Id == Id).SingleOrDefault();
            return itemss;
        }

        public void CreateItems(Items item)
        {
            items.Add(item);
        }

        public void UpdateItems(Items item)
        {
            var index= items.FindIndex(items=>items.Id == item.Id);

            items[index]= item;

        }

       
        public void DeleteItems(Guid id)
        {
            var index = items.FindIndex(items => items.Id == id);

            items.RemoveAt(index);
        }
    }
}
