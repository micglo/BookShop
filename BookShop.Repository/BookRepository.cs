using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(Book entity)
        {
            //Wyszukujemy aktualna książkę
            var actualBook = await Find(entity.Id);


            //Wszystkie jej powiążania, aktualne i zmienione
            var actualAuthors = actualBook.Author.ToList();
            var deletedAuthors = actualAuthors.Except(entity.Author).ToList();
            var addedAuthors = entity.Author.Except(actualAuthors).ToList();
            var actualSubMainCategories = actualBook.SubMainCategories.ToList();
            var deletedSubMainCategories = actualSubMainCategories.Except(entity.SubMainCategories).ToList();
            var addedSubMainCategories = entity.SubMainCategories.Except(actualSubMainCategories).ToList();
            var actualBookCategories = actualBook.BookCategories.ToList();
            var deletedBookCategories = actualBookCategories.Except(entity.BookCategories).ToList();
            var addedBookCategories = entity.BookCategories.Except(actualBookCategories).ToList();


            //Update relacji
            foreach (var deletedAuthor in deletedAuthors)
            {
                actualBook.Author.Remove(deletedAuthor);
            }

            foreach (var addedAuthor in addedAuthors)
            {
                if (Context.Entry(addedAuthor).State == EntityState.Detached)
                    Context.Authors.Attach(addedAuthor);
                actualBook.Author.Add(addedAuthor);
            }
            
            foreach (var deletedSubMainCategory in deletedSubMainCategories)
            {
                actualBook.SubMainCategories.Remove(deletedSubMainCategory);
            }

            foreach (var addedSubMainCategory in addedSubMainCategories)
            {
                if (Context.Entry(addedSubMainCategory).State == EntityState.Detached)
                    Context.SubMainCategories.Attach(addedSubMainCategory);
                actualBook.SubMainCategories.Add(addedSubMainCategory);
            }

            foreach (var deletedBookCategory in deletedBookCategories)
            {
                actualBook.BookCategories.Remove(deletedBookCategory);
            }

            foreach (var addedBookCategory in addedBookCategories)
            {
                if (Context.Entry(addedBookCategory).State == EntityState.Detached)
                    Context.BookCategories.Attach(addedBookCategory);
                actualBook.BookCategories.Add(addedBookCategory);
            }


            Context.SaveChanges();

            var local = Context.Set<Book>()
                .Local
                .FirstOrDefault(b => b.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(Book entity)
        {
            var local = Context.Set<Book>()
                .Local
                .FirstOrDefault(b => b.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Remove(entity);
        }

        public Book FindSync(object id)
            => DbSet.Find(id);
    }
}