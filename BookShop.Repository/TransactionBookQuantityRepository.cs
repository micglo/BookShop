using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class TransactionBookQuantityRepository : GenericRepository<TransactionBookQuantity>, ITransactionBookQuantityRepository
    {
        public TransactionBookQuantityRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(TransactionBookQuantity entity)
        {
            var local = Context.Set<TransactionBookQuantity>()
                .Local
                .FirstOrDefault(t => t.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(TransactionBookQuantity entity)
        {
            var local = Context.Set<TransactionBookQuantity>()
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