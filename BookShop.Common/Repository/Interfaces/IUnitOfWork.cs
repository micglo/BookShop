using System.Threading.Tasks;

namespace BookShop.Common.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IBookCategoryRepository BookCategoryRepository { get; }
        IBookReviewRepository BookReviewRepository { get; }
        IMainCategoryRepository MainCategoryRepository { get; }
        IPublishingRepository PublishingRepository { get; }
        ISubMainCategoryRepository SubMainCategoryRepository { get; }
        Task<int> SaveChangesAsync();
    }
}