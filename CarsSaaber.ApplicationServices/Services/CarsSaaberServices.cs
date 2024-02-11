using CarsSaaber.Core.Domain;
using CarsSaaber.Core.Dto;
using CarsSaaber.Core.ServiceInterface;
using CarsSaaber.Data;
using Microsoft.EntityFrameworkCore;

namespace CarsSaaber.ApplicationServices.Services
{
    public class CarsSaaberServices : ICarsSaaberServices
    {
        private readonly CarsContext _context;

        public CarsSaaberServices
            (
                CarsContext context
            )
        {
            _context = context;
        }

        public async Task<Cars> Create(CarsDto dto)
        {
            Cars car = new Cars();

            car.Id = Guid.NewGuid();
            car.Price = dto.Price;
            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.Year = dto.Year;
            car.Color = dto.Color;
            car.Discount = dto.Discount;

            car.CreatedAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;


            await _context.CarsSaaber.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Cars> Delete(Guid id)
        {
            var carId = await _context.CarsSaaber
               .FirstOrDefaultAsync(x => x.Id == id);

            _context.CarsSaaber.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }

        public async Task<Cars> GetAsync(Guid id)
        {
            var result = await _context.CarsSaaber
                .FirstOrDefaultAsync(x => x.Id == id);
            return (result);
        }

        public async Task<Cars> Update(CarsDto dto)
        {

            var domain = new Cars();

            domain.Id = dto.Id;
            domain.Price = dto.Price;
            domain.Brand = dto.Brand;
            domain.Model = dto.Model;
            domain.Year = dto.Year;
            domain.Color = dto.Color;
            domain.Discount = dto.Discount;

            domain.CreatedAt = DateTime.Now;
            domain.UpdatedAt = DateTime.Now;

            _context.CarsSaaber.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}
