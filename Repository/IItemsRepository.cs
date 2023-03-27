using SwordShop.Entities;

namespace SwordShop.Repository
{
    public interface IItemsRepository
    {
        Items GetItem(Guid Id);
        IEnumerable<Items> GetItems();

        void CreateItems(Items items);

        void UpdateItems(Items items);

        void DeleteItems(Guid id);
    }
}