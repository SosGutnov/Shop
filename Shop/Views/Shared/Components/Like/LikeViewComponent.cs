using Microsoft.AspNetCore.Mvc;
using Shop.Db;
using Shop.Helpers;
using Shop.Models;
using ShopDb;

namespace Shop.Views.Shared.Components.Cart
{

    public class LikeViewComponent:ViewComponent
    {
        private readonly DatabaseContext databaseContext;

        public LikeViewComponent(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IViewComponentResult Invoke(Guid productId)
        {
            if (databaseContext.Liked.FirstOrDefault(x=>x.Product.Id == productId) != null)
                return View("Like", "currentColor");
            return View("Like", "none");
        }
    }
}
