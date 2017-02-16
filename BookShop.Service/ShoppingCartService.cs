using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModels;
using BookShop.Models.ViewModels.ShoppingCart;
using BookShop.Repository.Interfaces;
using BookShop.Service.Interfaces;

namespace BookShop.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<ShoppingCartViewModel> GetShoppingCart(ShoppingCartSession shoppingCart, string returnUrl = null)
        {
            var shoppingCartLines = await MapShoppingCartLines(shoppingCart.ShoppingCartLines);
            var delivery = await SetDelivery(shoppingCart);
            shoppingCart.ReturnUrl = returnUrl;

            return new ShoppingCartViewModel
            {
                ReturnUrl = returnUrl,
                ShoppingCartLines = shoppingCartLines,
                TotalProductsValue = ComputeTotalProductValue(shoppingCartLines),
                TotalCost = ComputeTotalCost(shoppingCartLines, delivery.Price),
                Delivery = delivery,
                Payment = await SetPayment(shoppingCart),
                DeliveryOptions = await SetDeliveryOptions(shoppingCart),
                PaymentOptions = await SetPaymentOptions(shoppingCart)
            };
        }


        public async Task<ShoppingCartViewModel> GetShoppingCartModalIndex(ShoppingCartSession shoppingCart)
        {
            var shoppingCartLines = await MapShoppingCartLines(shoppingCart.ShoppingCartLines);
            shoppingCart.ReturnUrl = shoppingCart.ReturnUrl;

            return new ShoppingCartViewModel
            {
                ShoppingCartLines = shoppingCartLines,
                ReturnUrl = shoppingCart.ReturnUrl,
                TotalProductsValue = ComputeTotalProductValue(shoppingCartLines)
            };
        }

        public ShoppingCartViewModel GetShoppingCartModal(ShoppingCartSession shoppingCart)
        {
            var shoppingCartLines = MapShoppingCartLinesSync(shoppingCart.ShoppingCartLines);
            shoppingCart.ReturnUrl = shoppingCart.ReturnUrl;

            return new ShoppingCartViewModel
            {
                ShoppingCartLines = shoppingCartLines,
                ReturnUrl = shoppingCart.ReturnUrl,
                TotalProductsValue = ComputeTotalProductValue(shoppingCartLines)
            };
        }

        //Zwraca ilość wszystkich produktów w koszyku
        public int GetTotalItem(ShoppingCartSession shoppingCart)
            => shoppingCart.ShoppingCartLines.Sum(x => x.Quantity);


        public void AddItem(ShoppingCartSession shoppingCart, int bookId)
        {
            //Wyszukuje konkretna linie koszyka, aby ją zmodyfikować
            var line = shoppingCart.ShoppingCartLines.FirstOrDefault(l => l.BookId == bookId);

            if (line == null)
                shoppingCart.ShoppingCartLines.Add(new ShoppingCartLineSession
                {
                    BookId = bookId,
                    Quantity = 1
                });
            else
                line.Quantity += 1;
        }


        public void RemoveItem(ShoppingCartSession shoppingCart, int bookId)
        {
            var line = shoppingCart.ShoppingCartLines.FirstOrDefault(l => l.BookId == bookId);
            if (line?.Quantity > 1)
                line.Quantity -= 1;
            else
                RemoveLine(shoppingCart, bookId);
        }


        public void RemoveLine(ShoppingCartSession shoppingCart, int bookId)
            => shoppingCart.ShoppingCartLines.RemoveAll(l => l.BookId == bookId);


        //Czyści cały koszyk
        public void Clear(ShoppingCartSession shoppingCart)
            => shoppingCart.ShoppingCartLines.Clear();


        //Zmienia stan ilości wybranego produktu
        public async Task UpdateQuantity(ShoppingCartSession shoppingCart, int bookId, int quantity)
        {
            var shoppingCartLines = shoppingCart.ShoppingCartLines;
            var line = shoppingCartLines.FirstOrDefault(l => l.BookId == bookId);
            var book = await _unitOfWork.BookRepository.Find(bookId);

            if (line == null)
            {
                if (quantity > 0 && quantity <= book.Quantity)
                    shoppingCartLines.Add(new ShoppingCartLineSession
                    {
                        BookId = bookId,
                        Quantity = quantity
                    });
                else if (quantity > book.Quantity)
                    shoppingCartLines.Add(new ShoppingCartLineSession
                    {
                        BookId = bookId,
                        Quantity = book.Quantity
                    });
            }
            else
            {
                if (quantity > 0 && quantity <= book.Quantity)
                    line.Quantity = quantity;
                else if (quantity > book.Quantity)
                    line.Quantity = book.Quantity;
                else
                    shoppingCartLines.RemoveAll(l => l.BookId == book.Id);
            }
        }


        //Ustawia sposób dostawy
        public async Task ChangeDelivery(ShoppingCartSession shoppingCart, string deliveryType)
            => shoppingCart.Delivery = await _unitOfWork.DeliveryRepository.SingleOrDefault(d => d.DeliveryType.Equals(deliveryType));


        //Ustawia forme płatności
        public async Task ChangePayment(ShoppingCartSession shoppingCart, string paymentType)
            => shoppingCart.Payment = await _unitOfWork.PaymentRepository.SingleOrDefault(p => p.PaymentType.Equals(paymentType));


        //Zwraca aktualnie wybraną formę dostarczenia(adres)
        public DeliveryDataViewModel GetDeliveryData(ShoppingCartSession shoppingCart, ApplicationUser user)
            => new DeliveryDataViewModel
            {
                User = user,
                OtherDeliveryAddress = shoppingCart.OtherDeliveryAddressViewModel.OtherDeliveryAddress
            };


        public OtherDeliveryAddressViewModel GetDeliveryAddressViewModel(ShoppingCartSession shoppingCart)
            => shoppingCart.OtherDeliveryAddressViewModel;


        public void SetDeliveryAddress(ShoppingCartSession shoppingCart, OtherDeliveryAddressViewModel model)
        {
            shoppingCart.OtherDeliveryAddressViewModel = model;
            shoppingCart.OtherDeliveryAddressViewModel.OtherDeliveryAddress = model.OtherDeliveryAddress;
        }

        public bool IsOtherDeliveryAddress(ShoppingCartSession shoppingCart)
            => shoppingCart.OtherDeliveryAddressViewModel.OtherDeliveryAddress;


        public async Task<SummaryViewModel> GetSummaryViewModel(ShoppingCartSession shoppingCart, ApplicationUser user)
        {
            var model = await GetShoppingCart(shoppingCart);
            return new SummaryViewModel
            {
                ShoppingCartLines = model.ShoppingCartLines,
                TotalProductsValue = model.TotalProductsValue,
                TotalCost = model.TotalCost,
                Delivery = model.Delivery,
                Payment = model.Payment,
                OtherDeliveryAddress = shoppingCart.OtherDeliveryAddressViewModel,
                User = user
            };
        }

        public async Task<InfoViewModel> Checkout(ShoppingCartSession shoppingCart, ApplicationUser user)
        {
            var shoppingCartLines = await MapShoppingCartLines(shoppingCart.ShoppingCartLines);

            var deliveryAddress = new DeliveryAddress();
            if (shoppingCart.OtherDeliveryAddressViewModel.OtherDeliveryAddress)
            {
                deliveryAddress.FirstName = shoppingCart.OtherDeliveryAddressViewModel.FirstName;
                deliveryAddress.LastName = shoppingCart.OtherDeliveryAddressViewModel.LastName;
                deliveryAddress.Street = shoppingCart.OtherDeliveryAddressViewModel.Street;
                deliveryAddress.City = shoppingCart.OtherDeliveryAddressViewModel.City;
                deliveryAddress.PostCode = shoppingCart.OtherDeliveryAddressViewModel.PostCode;
                deliveryAddress.PhoneNumber = shoppingCart.OtherDeliveryAddressViewModel.PhoneNumber;
            }

            //jeśli nie zaznaczył to dane z profilu
            else
            {
                deliveryAddress.FirstName = user.FirstName;
                deliveryAddress.LastName = user.LastName;
                deliveryAddress.Street = user.Street;
                deliveryAddress.City = user.City;
                deliveryAddress.PostCode = user.PostCode;
                deliveryAddress.PhoneNumber = user.PhoneNumber;
            }

            var transactionModel = new Transaction
            {
                UserId = user.Id,
                DeliveryId = shoppingCart.Delivery.Id,
                PaymentId = shoppingCart.Payment.Id,
                TransactionDate = DateTime.Now,
                TransactionStatus = TransactionStatus.New,
                TransactionAmount = ComputeTotalCost(shoppingCartLines, shoppingCart.Delivery.Price),
                DeliveryAddress = deliveryAddress
            };

            var transaction = await _unitOfWork.TransactionRepository.Add(transactionModel);


            foreach (var cartLine in shoppingCartLines)
            {
                var transactionBookQuantity = new TransactionBookQuantity
                {
                    BookId = cartLine.Book.Id,
                    Quantity = cartLine.Quantity,
                    TransactionId = transaction.Id,
                    BookPrice = cartLine.Book.Price
                };
                await _unitOfWork.TransactionBookQuantityRepository.Add(transactionBookQuantity);

                var book = await _unitOfWork.BookRepository.Find(cartLine.Book.Id);

                //zakupiony produkt nie jest na fizycznym stanie magazynu dlatego zmniejszamy jego ilość
                book.Quantity -= cartLine.Quantity;
                await _unitOfWork.BookRepository.Update(book);
            }

            //czyścimy koszyk
            Clear(shoppingCart);

            var vm = new InfoViewModel
            {
                Message = "Dziękujemy za dokonane zakupy. Status realizacji zlecenia możesz przeglądać w opcjach swojego profilu."
            };

            return vm;
        }


        #region Helpers

        private async Task<List<ShoppingCartLine>> MapShoppingCartLines(IEnumerable<ShoppingCartLineSession> shoppingCartLineList)
        {
            var shoppingCartLines = new List<ShoppingCartLine>();
            foreach (var shoppingCartLineSession in shoppingCartLineList)
            {
                var book = await _unitOfWork.BookRepository.Find(shoppingCartLineSession.BookId);
                shoppingCartLines.Add(new ShoppingCartLine
                {
                    Book = book,
                    Quantity = shoppingCartLineSession.Quantity
                });

            }

            return shoppingCartLines;
        }


        private List<ShoppingCartLine> MapShoppingCartLinesSync(IEnumerable<ShoppingCartLineSession> shoppingCartLineList)
            => shoppingCartLineList.Select(l => new ShoppingCartLine
            {
                Book = _unitOfWork.BookRepository.FindSync(l.BookId),
                Quantity = l.Quantity
            }).ToList();


        //Wartość wszystkich produktów w koszyku
        private decimal ComputeTotalProductValue(List<ShoppingCartLine> shoppingCartLines)
            => shoppingCartLines.Sum(e => e.Book.Price * e.Quantity);


        private decimal ComputeTotalCost(List<ShoppingCartLine> shoppingCartLines, decimal deliveryPrice)
            => ComputeTotalProductValue(shoppingCartLines) + deliveryPrice;


        //Sprawdza możliwości dostawy zależnie od wybranego rodzaju produktów
        private async Task<Delivery> SetDelivery(ShoppingCartSession shoppingCart)
        {
            var onlyElectronic = await CheckIfOnlyElectronic(shoppingCart);

            if (shoppingCart.Delivery == null)
            {
                if (onlyElectronic)
                    return await SetOnlyElectronicDelivery(shoppingCart);

                return await SetCourierDelivery(shoppingCart);
            }

            if (onlyElectronic)
                return await SetOnlyElectronicDelivery(shoppingCart);

            if (!onlyElectronic && shoppingCart.Delivery.DeliveryType.Equals("Przesyłka elektroniczna"))
                return await SetCourierDelivery(shoppingCart);

            return shoppingCart.Delivery;
        }


        //sprawdza możliwości płatności w zależności od wybranego rodzaju produktu
        private async Task<Payment> SetPayment(ShoppingCartSession shoppingCart)
        {
            var onlyElectronic = await CheckIfOnlyElectronic(shoppingCart);

            if (shoppingCart.Payment == null)
                return await SetCreditCardPayment(shoppingCart);

            if (onlyElectronic && (shoppingCart.Payment.PaymentType.Equals("Płatność przy odbiorze") ||
                    shoppingCart.Payment.PaymentType.Equals("Płatność za pobraniem")))
                await SetCreditCardPayment(shoppingCart);

            return shoppingCart.Payment;
        }


        //Sprawdza czy wszystkie są elektroniczne (ebook, audiobook)
        private async Task<bool> CheckIfOnlyElectronic(ShoppingCartSession shoppingCart)
        {
            var shoppingCartLines = await MapShoppingCartLines(shoppingCart.ShoppingCartLines);

            return shoppingCartLines.All(
                x =>
                x.Book.SubMainCategories.Any(
                    s => s.MainCategory.Name.Equals("Ebooki") || s.MainCategory.Name.Equals("Audiobooki")));
        }


        //Opcje tylko dla elektronicznych (ebook, audiobook)
        private async Task<Delivery> SetOnlyElectronicDelivery(ShoppingCartSession shoppingCart)
        {
            var electronicDelivery = await _unitOfWork.DeliveryRepository.SingleOrDefault(x => x.DeliveryType.Equals("Przesyłka elektroniczna"));
            shoppingCart.Delivery = electronicDelivery;

            return electronicDelivery;
        }


        private async Task<Delivery> SetCourierDelivery(ShoppingCartSession shoppingCart)
        {
            var courierDelivery = await _unitOfWork.DeliveryRepository.SingleOrDefault(x => x.DeliveryType.Equals("Przesyłka kurierska"));
            shoppingCart.Delivery = courierDelivery;

            return courierDelivery;
        }


        private async Task<Payment> SetCreditCardPayment(ShoppingCartSession shoppingCart)
        {
            var creditCardPayment = await _unitOfWork.PaymentRepository.SingleOrDefault(x => x.PaymentType.Equals("Płatność kartą kredytową"));
            shoppingCart.Payment = creditCardPayment;

            return creditCardPayment;
        }


        //Ustawia możliwośći dostawy
        private async Task<List<Delivery>> SetDeliveryOptions(ShoppingCartSession shoppingCart)
        {
            var deliveryOptions = new List<Delivery>();
            var onlyElectronic = await CheckIfOnlyElectronic(shoppingCart);

            if (onlyElectronic)
            {
                var delivery =
                    await _unitOfWork.DeliveryRepository.SingleOrDefault(x => x.DeliveryType.Equals("Przesyłka elektroniczna"));
                deliveryOptions.Add(delivery);
            }

            else
            {
                var noElectronicDeliveries =
                    await _unitOfWork.DeliveryRepository.FindAll(x => !x.DeliveryType.Equals("Przesyłka elektroniczna"));

                deliveryOptions.AddRange(noElectronicDeliveries);
            }

            return deliveryOptions;
        }


        //Ustawia możliwości płatności
        private async Task<List<Payment>> SetPaymentOptions(ShoppingCartSession shoppingCart)
        {
            var paymentOptions = new List<Payment>();
            var onlyElectronic = await CheckIfOnlyElectronic(shoppingCart);

            if (onlyElectronic)
            {
                var payment =
                    await _unitOfWork.PaymentRepository.FindAll(x => x.PaymentType.Equals("Płatność kartą kredytową") || x.PaymentType.Equals("Płatność przelewem bankowym"));
                paymentOptions.AddRange(payment);
            }

            else
            {
                var allPaymentOptions =
                    await _unitOfWork.PaymentRepository.GetAll();

                paymentOptions.AddRange(allPaymentOptions);
            }

            return paymentOptions;
        }

        #endregion
    }
}