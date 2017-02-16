using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Service.Interfaces;
using BookShop.Web.Common.filters;
using BookShop.Web.Controllers;

namespace BookShop.Web.Areas.Admin.Controllers
{
    //[MyAuthorize(Roles = "Admin,Employee")]
    public class TransactionsController : BaseController
    {
        public TransactionsController(ITransactionService transactionService)
        {
            TransactionService = transactionService;
        }


        public async Task<ActionResult> Index()
            => View(await TransactionService.GetAllByStatus("All"));


        //Przeladowanie tabeli w zależności od wybranego statusu zlecenia
        public async Task<ActionResult> GetAllByStatus(string status)
            => PartialView(await TransactionService.GetAllByStatus(status));


        public async Task<ActionResult> Details(int id)
        {
            var transactionExists = await TransactionService.TransactionExists(id);
            if (!transactionExists)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return View(await TransactionService.GetTransationDetail(id));
        }


        public async Task<ActionResult> ChangeStatus(int id)
            => PartialView(await TransactionService.ChangeStatus(id));


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeStatusPost(int transactionId, string transactionStatus)
        {
            var result = await TransactionService.UpdateTransactionStatus(transactionId, transactionStatus);
            return PartialView("_infoPartial", result);
        }


        //Do wyświetlenia zmiany statusu bez przeladowania calej tabeli
        public async Task<ActionResult> GetTransactionStatus(int id)
            => Json(await TransactionService.GetTransactionStatus(id), JsonRequestBehavior.AllowGet);
    }
}