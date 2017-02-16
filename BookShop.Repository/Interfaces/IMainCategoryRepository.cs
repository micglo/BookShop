using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Data;

namespace BookShop.Repository.Interfaces
{
    public interface IMainCategoryRepository : IGenericRepository<MainCategory>
    {
        IEnumerable<MainCategory> GetAllCategories(
            Func<IQueryable<MainCategory>, IOrderedQueryable<MainCategory>> orderBy = null,
            int? skip = null, int? take = null);
    }
}