using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Common.Repository.Interfaces;
using BookShop.Common.Service.Interfaces;
using BookShop.Data;

namespace BookShop.Common.Service
{
    public class PublishingService : GenericService<Publishing>, IPublishingService
    {
        public PublishingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<IEnumerable<Publishing>> GetAllAsync()
            => await UnitOfWork.PublishingRepository.GetAllAsync();

        public override async Task<Publishing> GetByIdAsync(object id)
        => await UnitOfWork.PublishingRepository.FindAsync(id);

        public override async Task AddAsync(Publishing model)
        {
            UnitOfWork.PublishingRepository.Add(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Publishing model)
        {
            UnitOfWork.PublishingRepository.Update(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task DeleteAsync(long id)
        {
            var publishing = await GetByIdAsync(id);
            UnitOfWork.PublishingRepository.Remove(publishing);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<Publishing> GetByNameAsync(string name)
            => await UnitOfWork.PublishingRepository.SingleOrDefaultAsync(p => p.Name.Equals(name));
    }
}