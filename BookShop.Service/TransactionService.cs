using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Data;
using BookShop.Models.ViewModels;
using BookShop.Models.ViewModels.Transaction;
using BookShop.Repository.Interfaces;
using BookShop.Service.Interfaces;

namespace BookShop.Service
{
    public class TransactionService : GenericService<Transaction>, ITransactionService
    {
        public TransactionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public async Task<IEnumerable<TransactionIndexViewModel>> GetAllByStatus(string status)
        {
            IEnumerable<Transaction> transactions;

            //pobiera tansakcje w zależności od frazy statusu 
            if (status.Equals("All"))
            {
                transactions = await UnitOfWork.TransactionRepository.GetAll();
            }
            else
            {
                var transactionStatus = GetStatus(status);
                transactions = await UnitOfWork.TransactionRepository.FindAll(t => t.TransactionStatus == transactionStatus);
            }

            var vm = transactions.Select(t => new TransactionIndexViewModel
            {
                Id = t.Id,
                Date = t.TransactionDate.ToString("d"),
                TransactionAmount = t.TransactionAmount.ToString("c"),
                Status = GetDescription(t.TransactionStatus),
                Person = t.User.FirstName + " " + t.User.LastName
            });

            return vm;
        }


        public async Task<IEnumerable<MyTransactionsViewModel>> GetAllByUserId(string userId)
        {
            var userTransactions = await
                UnitOfWork.TransactionRepository.FindAll(x => x.UserId.Equals(userId),
                    x => x.OrderByDescending(d => d.TransactionDate).ThenBy(s => s.TransactionStatus));

            return userTransactions.Select(transaction => new MyTransactionsViewModel
            {
                Id = transaction.Id,
                Date = transaction.TransactionDate.ToString("d"),
                Status = GetDescription(transaction.TransactionStatus),
                TransactionAmount = transaction.TransactionAmount.ToString("C")
            }).ToList();
        }


        public async Task<Transaction> GetById(int id)
            => await UnitOfWork.TransactionRepository.Find(id);


        public async Task<TransactionDetailViewModel> GetTransationDetail(int id)
        {
            var transaction = await UnitOfWork.TransactionRepository.Find(id);

            var vm = new TransactionDetailViewModel
            {
                Id = transaction.Id,
                Date = transaction.TransactionDate.ToString("d"),
                Status = GetDescription(transaction.TransactionStatus),
                TransactionAmount = transaction.TransactionAmount.ToString("C"),
                Delivery = transaction.Delivery,
                Payment = transaction.Payment,
                BookQuantities = transaction.TransactionBookQuantities,
                DeliveryAddress = transaction.DeliveryAddress
            };

            return vm;
        }


        public async Task<string> GetTransactionStatus(int id)
        {
            var transaction = await UnitOfWork.TransactionRepository.Find(id);
            return GetDescription(transaction.TransactionStatus);
        }


        public async Task<bool> TransactionExists(int id)
            => await UnitOfWork.TransactionRepository.Any(x => x.Id == id);


        //Metoda zwracająca model dla select listy do wyboru zmiany statusu zamówienia
        public async Task<ChangeStatusViewModel> ChangeStatus(int id)
        {
            var transaction = await UnitOfWork.TransactionRepository.Find(id);
            var statusStringList = (from TransactionStatus status in Enum.GetValues(typeof(TransactionStatus)) select GetDescription(status)).ToList();

            return new ChangeStatusViewModel
            {
                TransactionId = transaction.Id,
                TransactionStatusSelectList = new SelectList(statusStringList, GetDescription(transaction.TransactionStatus))
            };
        }


        public async Task<InfoViewModel> UpdateTransactionStatus(int transactionId, string transactionStatus)
        {
            var transaction = await UnitOfWork.TransactionRepository.Find(transactionId);
            transaction.TransactionStatus = GetStatus(transactionStatus);
            await UnitOfWork.TransactionRepository.Update(transaction);

            var result = new InfoViewModel
            {
                Message = "Status transakcji nr. " + transactionId + " został zmieniony"
            };

            return result;
        }


        #region Helpers

        //private string SetStatus(TransactionStatus status)
        //{
        //    switch (status)
        //    {
        //        case TransactionStatus.Done:
        //            return "Zakończona";
        //        case TransactionStatus.InProces:
        //            return "W trakcje realizacji";
        //        default:
        //            return "Złożona";
        //    }
        //}
        //private string SetStatus(TransactionStatus status)
        //{
        //    var type = typeof(TransactionStatus);
        //    var memInfo = type.GetMember(status.ToString());
        //    var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
        //        false);
        //    return ((DescriptionAttribute)attributes[0]).Description;
        //}

        private TransactionStatus GetStatus(string status)
        {
            switch (status)
            {
                case "Zakończona":
                    return TransactionStatus.Done;
                case "W trakcje realizacji":
                    return TransactionStatus.InProces;
                default:
                    return TransactionStatus.New;
            }
        }

        #endregion
    }
}