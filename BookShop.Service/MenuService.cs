using BookShop.Models.ViewModels.Menu;
using BookShop.Repository.Interfaces;
using BookShop.Service.Interfaces;

namespace BookShop.Service
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MenuCategoriesViewModel GetAllCategories()
            => new MenuCategoriesViewModel
            {
                MainCategories = _unitOfWork.MainCategoryRepository.GetAllCategories(),
                SubMainCategories = _unitOfWork.SubMainCategoryRepository.GetAllCategories()
            };
    }
}