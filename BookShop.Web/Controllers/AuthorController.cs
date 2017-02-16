using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Service.Interfaces;

namespace BookShop.Web.Controllers
{
    [RoutePrefix("Autor")]
    public class AuthorController : BaseController
    {
        public AuthorController(IAuthorService authorService)
        {
            AuthorService = authorService;
        }

        [Route("{id:int}/{lastName}", Name = "GetAuthor")]
        public async Task<ActionResult> GetAuthor(int id, string lastName)
        {
            var authorExists = await AuthorService.Exists(id, lastName);
            if (!authorExists)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(await AuthorService.GetById(id));
        }
    }
}