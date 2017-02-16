using BookShop.Data;

namespace BookShop.Repository.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Book FindSync(object id);
    }
}