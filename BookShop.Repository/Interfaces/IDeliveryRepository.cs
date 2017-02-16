using System;
using System.Linq.Expressions;
using BookShop.Data;

namespace BookShop.Repository.Interfaces
{
    public interface IDeliveryRepository : IGenericRepository<Delivery>
    {
        Delivery SingleOrDefaultSync(Expression<Func<Delivery, bool>> filter);
    }
}