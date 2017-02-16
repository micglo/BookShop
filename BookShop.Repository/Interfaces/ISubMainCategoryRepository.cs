using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Data;

namespace BookShop.Repository.Interfaces
{
    public interface ISubMainCategoryRepository : IGenericRepository<SubMainCategory>
    {
        IEnumerable<SubMainCategory> GetAllCategories(
            Func<IQueryable<SubMainCategory>, IOrderedQueryable<SubMainCategory>> orderBy = null,
            int? skip = null, int? take = null);
    }
}