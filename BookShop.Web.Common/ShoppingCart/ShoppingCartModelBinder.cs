using System.Collections.Generic;
using System.Web.Mvc;
using BookShop.Models.ViewModels.ShoppingCart;

namespace BookShop.Web.Common.ShoppingCart
{
    /// <summary>
    /// Model binder koszyka
    /// </summary>
    public class ShoppingCartModelBinder : IModelBinder
    {
        private const string SessionKey = "ShoppingCart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ShoppingCartSession shoppingCart = null;

            if (controllerContext.HttpContext.Session != null)
            {
                shoppingCart = (ShoppingCartSession)controllerContext.HttpContext.Session[SessionKey];
            }

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCartSession
                {
                    ShoppingCartLines = new List<ShoppingCartLineSession>()
                };

                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = shoppingCart;
                }
            }

            return shoppingCart;
        }
    }
}