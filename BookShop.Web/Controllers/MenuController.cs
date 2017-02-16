using System.Web.Mvc;
using BookShop.Service.Interfaces;

namespace BookShop.Web.Controllers
{
    public class MenuController : BaseController
    {
        public MenuController(IMenuService menuService)
        {
            MenuService = menuService;
        }


        public PartialViewResult MenuCategories()
            => PartialView(MenuService.GetAllCategories());


        public PartialViewResult MenuSearch()
            => PartialView();
    }
}