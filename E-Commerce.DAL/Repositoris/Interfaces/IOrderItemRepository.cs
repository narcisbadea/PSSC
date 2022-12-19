using E_Commerce.Domain.Models;

namespace E_Commerce.DAL.Repositoris.Interfaces
{
    public interface IOrderItemRepository
    {
        Task AddItemInOrder(Item item, User user, int quantity);
    }
}