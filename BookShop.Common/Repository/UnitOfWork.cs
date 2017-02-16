using System.Threading.Tasks;
using BookShop.Common.Repository.Interfaces;
using BookShop.Data.Sql;

namespace BookShop.Common.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            AuthorRepository = new AuthorRepository(_context);
            BookRepository = new BookRepository(_context);
            BookCategoryRepository =  new BookCategoryRepository(_context);
            BookReviewRepository = new BookReviewRepository(_context);
            MainCategoryRepository = new MainCategoryRepository(_context);
            PublishingRepository = new PublishingRepository(_context);
            SubMainCategoryRepository = new SubMainCategoryRepository(_context);
        }

        public IAuthorRepository AuthorRepository { get; }
        public IBookRepository BookRepository { get; }
        public IBookCategoryRepository BookCategoryRepository { get; }
        public IBookReviewRepository BookReviewRepository { get; }
        public IMainCategoryRepository MainCategoryRepository { get; }
        public IPublishingRepository PublishingRepository { get; }
        public ISubMainCategoryRepository SubMainCategoryRepository { get; }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}