using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Common.Repository.Interfaces;
using BookShop.Common.Service.Interfaces;
using BookShop.Data;

namespace BookShop.Common.Service
{
    public class MainCategoryService : GenericService<MainCategory>, IMainCategoryService
    {
        public MainCategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<IEnumerable<MainCategory>> GetAllAsync()
            => await UnitOfWork.MainCategoryRepository.GetAllAsync();

        public override async Task<MainCategory> GetByIdAsync(object id)
            => await UnitOfWork.MainCategoryRepository.FindAsync(id);

        public override async Task AddAsync(MainCategory model)
        {
            UnitOfWork.MainCategoryRepository.Add(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task UpdateAsync(MainCategory model)
        {
            UnitOfWork.MainCategoryRepository.Update(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task DeleteAsync(long id)
        {
            var mainCategory = await GetByIdAsync(id);
            UnitOfWork.MainCategoryRepository.Remove(mainCategory);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}