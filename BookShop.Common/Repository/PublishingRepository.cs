using System.Data.Entity;
using System.Linq;
using BookShop.Common.Repository.Interfaces;
using BookShop.Data;
using BookShop.Data.Sql;

namespace BookShop.Common.Repository
{
    public class PublishingRepository : GenericRepository<Publishing>, IPublishingRepository
    {
        public PublishingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Update(Publishing entity)
        {
            var local = Context.Set<Publishing>()
                .Local
                .FirstOrDefault(p => p.PublishingId == entity.PublishingId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Update(entity);
        }

        public override void Remove(Publishing entity)
        {
            var local = Context.Set<Publishing>()
                .Local
                .FirstOrDefault(p => p.PublishingId == entity.PublishingId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Remove(entity);
        }
    }
}