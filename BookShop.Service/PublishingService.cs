using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModels;
using BookShop.Repository.Interfaces;
using BookShop.Service.Interfaces;

namespace BookShop.Service
{
    public class PublishingService : GenericService<Publishing>, IPublishingService
    {
        public PublishingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public async Task<IEnumerable<Publishing>> GetAll()
            => await UnitOfWork.PublishingRepository.GetAll();


        public async Task<Publishing> GetById(int id)
            => await UnitOfWork.PublishingRepository.Find(id);


        public async Task<Publishing> GetByNameAsync(string name)
            => await UnitOfWork.PublishingRepository.SingleOrDefault(p => p.Name.Equals(name));


        public async Task<InfoViewModel> Create(Publishing publishing)
        {
            //Jeśli takie wydawnictwo już istnieje to nie ma sensu znowu go dodawać
            var publishingExists =
                await UnitOfWork.PublishingRepository.Any(
                    x => x.Name.Equals(publishing.Name) && x.NameForDisplay.Equals(publishing.NameForDisplay));

            var vm = new InfoViewModel();

            if (!publishingExists)
            {
                await UnitOfWork.PublishingRepository.Add(publishing);
                vm.Message = "Nowe wydawnictwo zostało utworzone";
            }
            else
            {
                var msg = "Wydawnictwo " + publishing.Name + " już istnieje";
                vm.Errors = new List<string> { msg };
            }

            return vm;
        }


        public async Task<InfoViewModel> Edit(Publishing publishing)
        {
            await UnitOfWork.PublishingRepository.Update(publishing);

            return new InfoViewModel
            {
                Message = "Wydawnictwo zostało zmienione"
            };
        }


        public async Task<InfoViewModel> Delete(int id)
        {
            var publishing = await UnitOfWork.PublishingRepository.Find(id);
            await UnitOfWork.PublishingRepository.Remove(publishing);

            return new InfoViewModel
            {
                Message = "Wydawnictwo zostało usunięte"
            };
        }


        public async Task<IEnumerable<SelectListViewModel>> GetPublishingsForSelect(string searchString)
        {
            //Jeśli ktoś nie wybrał żadnego autora to zwraca wszystkich
            if (searchString.Equals("undefined"))
            {
                var allPublishings = await UnitOfWork.PublishingRepository.GetAll();
                return allPublishings.Select(p => new SelectListViewModel
                {
                    Id = p.Id.ToString(CultureInfo.InvariantCulture),
                    Text = p.NameForDisplay
                });
            }

            //zwraca autorów w zależności od wyszukiwanej frazy
            var publishings = await UnitOfWork.PublishingRepository.FindAll(p=>p.NameForDisplay.Contains(searchString));
            return publishings.Select(p => new SelectListViewModel
            {
                Id = p.Id.ToString(CultureInfo.InvariantCulture),
                Text = p.NameForDisplay
            });
        }


        public async Task<bool> Exists(string name)
            => await UnitOfWork.PublishingRepository.Any(p => p.Name.Equals(name));
    }
}