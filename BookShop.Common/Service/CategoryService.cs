//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using BookShop.Common.Repository.Interfaces;
//using BookShop.Common.Service.Interfaces;
//using BookShop.Data;
//using BookShop.Models.ViewModels;

//namespace BookShop.Common.Service
//{
//    public class CategoryService : GenericService<Category>, ICategoryService
//    {
//        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
//        {
//        }

//        public override async Task<IEnumerable<Category>> GetAllAsync()
//            => await UnitOfWork.CategoryRepository.GetAllAsync(q => q.OrderBy(c => c.Name));

//        public override Task<Category> GetByIdAsync(object id)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override Task AddAsync(Category model)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override Task UpdateAsync(Category model)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override Task DeleteAsync(long id)
//        {
//            throw new System.NotImplementedException();
//        }

//        public CategoryNamesViewModel GetCategoryNames(string categoryName = null)
//            => new CategoryNamesViewModel
//            {
//                CategoryNames = UnitOfWork.CategoryRepository.GetAll(q => q.OrderBy(c => c.Name)).Select(c => c.Name),
//                SelectedCategory = categoryName
//            };
//    }
//}