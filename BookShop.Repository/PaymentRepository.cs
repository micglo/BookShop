using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(Payment entity)
        {
            var local = Context.Set<Payment>()
                .Local
                .FirstOrDefault(p => p.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(Payment entity)
        {
            var local = Context.Set<Payment>()
                .Local
                .FirstOrDefault(p => p.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Remove(entity);
        }
    }
}