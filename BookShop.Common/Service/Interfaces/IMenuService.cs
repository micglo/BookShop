using BookShop.Models.ViewModels;

namespace BookShop.Common.Service.Interfaces
{
    public interface IMenuService
    {
        MenuCategoriesViewModel GetAllCategories();
    }
}