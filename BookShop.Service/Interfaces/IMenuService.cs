using BookShop.Models.ViewModels.Menu;

namespace BookShop.Service.Interfaces
{
    public interface IMenuService
    {
        MenuCategoriesViewModel GetAllCategories();
    }
}