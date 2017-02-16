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
    public class AuthorService : GenericService<Author>, IAuthorService
    {
        public AuthorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public async Task<IEnumerable<Author>> GetAll()
            => await UnitOfWork.AuthorRepository.GetAll();


        public async Task<Author> GetById(object id)
            => await UnitOfWork.AuthorRepository.Find(id);


        public async Task<InfoViewModel> Create(Author author)
        {
            //Jeśli taki autor już istnieje to nie ma sensu znowu go dodawać
            var autorExists =
                await UnitOfWork.AuthorRepository.Any(
                    x =>
                        x.FirstName.Equals(author.FirstName) && x.LastName.Equals(author.LastName) &&
                        x.LastNameForDisplay.Equals(author.LastNameForDisplay));

            var vm = new InfoViewModel();

            if (!autorExists)
            {
                await UnitOfWork.AuthorRepository.Add(author);
                vm.Message = "Nowy autor został utworzony";
            }
            else
            {
                var msg = "Autor " + author.FirstName + " " + author.LastName + " już istnieje";
                vm.Errors = new List<string> { msg };
            }

            return vm;
        }


        public async Task<InfoViewModel> Edit(Author author)
        {
            await UnitOfWork.AuthorRepository.Update(author);

            return new InfoViewModel
            {
                Message = "Autor został zmieniony"
            };
        }


        public async Task<InfoViewModel> Delete(int id)
        {
            var author = await UnitOfWork.AuthorRepository.Find(id);
            await UnitOfWork.AuthorRepository.Remove(author);

            return new InfoViewModel
            {
                Message = "Autor został usunięty"
            };
        }


        //Lista autorów do select listy
        public async Task<IEnumerable<SelectListViewModel>> GetAuthorsForSelect(string searchString)
        {
            //Jeśli ktoś nie wybrał żadnego autora to zwraca wszystkich
            if (searchString.Equals("undefined"))
            {
                var allAuthors = await UnitOfWork.AuthorRepository.GetAll();

                return allAuthors.Select(a => new SelectListViewModel
                {
                    Id = a.Id.ToString(CultureInfo.InvariantCulture),
                    Text = a.FirstName + " " + a.LastNameForDisplay
                });
            }

            //zwraca autorów w zależności od wyszukiwanej frazy
            var authors = await UnitOfWork.AuthorRepository.FindAll(a=>a.FirstName.Contains(searchString) || a.LastNameForDisplay.Contains(searchString));
            return authors.Select(a => new SelectListViewModel
            {
                Id = a.Id.ToString(CultureInfo.InvariantCulture),
                Text = a.FirstName + " " + a.LastNameForDisplay
            });
        }


        public async Task<bool> Exists(int id, string lastName)
            => await UnitOfWork.AuthorRepository.Any(a => a.Id == id && a.LastName.Equals(lastName));
    }
}