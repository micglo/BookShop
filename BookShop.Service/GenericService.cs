using System.ComponentModel;
using BookShop.Data.Common;
using BookShop.Repository.Interfaces;
using BookShop.Service.Interfaces;

namespace BookShop.Service
{
    public abstract class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        protected IUnitOfWork UnitOfWork;

        protected GenericService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected static string GetDescription<TEnum>(TEnum enumType)
        {
            var type = typeof(TEnum);
            var memInfo = type.GetMember(enumType.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
                false);
            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}