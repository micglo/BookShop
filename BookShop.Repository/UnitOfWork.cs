using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext context)
        {
            AuthorRepository = new AuthorRepository(context);
            AuthorReviewRepository = new AuthorReviewRepository(context);
            BookRepository = new BookRepository(context);
            BookCategoryRepository =  new BookCategoryRepository(context);
            BookReviewRepository = new BookReviewRepository(context);
            DeliveryRepository = new DeliveryRepository(context);
            MainCategoryRepository = new MainCategoryRepository(context);
            PaymentRepository = new PaymentRepository(context);
            PublishingRepository = new PublishingRepository(context);
            PublishingReviewRepository = new PublishingReviewRepository(context);
            SubMainCategoryRepository = new SubMainCategoryRepository(context);
            TransactionRepository = new TransactionRepository(context);
            TransactionBookQuantityRepository = new TransactionBookQuantityRepository(context);
        }

        #region Properties

        public IAuthorRepository AuthorRepository { get; }
        public IAuthorReviewRepository AuthorReviewRepository { get; }
        public IBookRepository BookRepository { get; }
        public IBookCategoryRepository BookCategoryRepository { get; }
        public IBookReviewRepository BookReviewRepository { get; }
        public IDeliveryRepository DeliveryRepository { get; }
        public IMainCategoryRepository MainCategoryRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IPublishingRepository PublishingRepository { get; }
        public IPublishingReviewRepository PublishingReviewRepository { get; }
        public ISubMainCategoryRepository SubMainCategoryRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
        public ITransactionBookQuantityRepository TransactionBookQuantityRepository { get; }

        #endregion
    }
}