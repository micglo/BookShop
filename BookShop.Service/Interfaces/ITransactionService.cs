using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModels;
using BookShop.Models.ViewModels.Transaction;

namespace BookShop.Service.Interfaces
{
    public interface ITransactionService : IGenericService<Transaction>
    {
        Task<IEnumerable<TransactionIndexViewModel>> GetAllByStatus(string status);

        Task<IEnumerable<MyTransactionsViewModel>> GetAllByUserId(string userId);

        Task<Transaction> GetById(int id);

        Task<TransactionDetailViewModel> GetTransationDetail(int id);

        Task<string> GetTransactionStatus(int id);

        Task<bool> TransactionExists(int id);

        Task<ChangeStatusViewModel> ChangeStatus(int id);

        Task<InfoViewModel> UpdateTransactionStatus(int transactionId, string transactionStatus);
    }
}