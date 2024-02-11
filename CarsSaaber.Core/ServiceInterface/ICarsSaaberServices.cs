using CarsSaaber.Core.Domain;
using CarsSaaber.Core.Dto;

namespace CarsSaaber.Core.ServiceInterface
{
    public interface ICarsSaaberServices
    {
        Task<Cars> Create(CarsDto dto);
        Task<Cars> Update(CarsDto dto);
        Task<Cars> Delete(Guid id);
        Task<Cars> GetAsync(Guid id);
    }
}
