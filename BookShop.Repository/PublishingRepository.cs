using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class PublishingRepository : GenericRepository<Publishing>, IPublishingRepository
    {
        public PublishingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(Publishing entity)
        {
            var local = Context.Set<Publishing>()
                .Local
                .FirstOrDefault(p => p.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(Publishing entity)
        {
            var local = Context.Set<Publishing>()
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