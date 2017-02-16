using BookShop.Common.Repository.Interfaces;
using BookShop.Common.Service.Interfaces;
using BookShop.Models.ViewModels;

namespace BookShop.Common.Service
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
                MainCategories = _unitOfWork.MainCategoryRepository.GetAll(),
                SubMainCategories = _unitOfWork.SubMainCategoryRepository.GetAll()
            };
    }
}