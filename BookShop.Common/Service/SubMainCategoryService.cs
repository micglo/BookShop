using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Common.Repository.Interfaces;
using BookShop.Common.Service.Interfaces;
using BookShop.Data;

namespace BookShop.Common.Service
{
    public class SubMainCategoryService : GenericService<SubMainCategory>, ISubMainCategoryService
    {
        public SubMainCategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<IEnumerable<SubMainCategory>> GetAllAsync()
            => await UnitOfWork.SubMainCategoryRepository.GetAllAsync();

        public override async Task<SubMainCategory> GetByIdAsync(object id)
        => await UnitOfWork.SubMainCategoryRepository.FindAsync(id);

        public override async Task AddAsync(SubMainCategory model)
        {
            UnitOfWork.SubMainCategoryRepository.Add(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task UpdateAsync(SubMainCategory model)
        {
            UnitOfWork.SubMainCategoryRepository.Update(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task DeleteAsync(long id)
        {
            var subMainCategory = await GetByIdAsync(id);
            UnitOfWork.SubMainCategoryRepository.Remove(subMainCategory);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}