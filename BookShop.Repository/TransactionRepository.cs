using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(Transaction entity)
        {
            var local = Context.Set<Transaction>()
                .Local
                .FirstOrDefault(t => t.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(Transaction entity)
        {
            var local = Context.Set<Transaction>()
                .Local
                .FirstOrDefault(t => t.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Remove(entity);
        }
    }
}