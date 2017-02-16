using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class DeliveryRepository : GenericRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(Delivery entity)
        {
            var local = Context.Set<Delivery>()
                .Local
                .FirstOrDefault(d => d.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(Delivery entity)
        {
            var local = Context.Set<Delivery>()
                .Local
                .FirstOrDefault(d => d.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Remove(entity);

        }


        /// <summary>
        /// Sztywne nie asynchroniczne zapytanie, aby wyświetlic dane synchronicznie
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Delivery SingleOrDefaultSync(Expression<Func<Delivery, bool>> filter) 
            => DbSet.SingleOrDefault(filter);
    }
}