using CarsSaaber.Core.Dto;
using CarsSaaber.Core.ServiceInterface;
using CarsSaaber.Data;
using CarsSaaber.Models.CarsSaaber;
using Microsoft.AspNetCore.Mvc;

namespace CarsSaaber.Controllers
{
    public class CarsSaaberController : Controller
    {
        private readonly CarsContext _context;
        private readonly ICarsSaaberServices _carServices;

        public CarsSaaberController
            (
                CarsContext context, 
                ICarsSaaberServices carServices
            )
        {
            _context = context;
            _carServices = carServices;
        }

        public IActionResult Index()
        {
            var result = _context.CarsSaaber
                .OrderBy((key) => key.CreatedAt)
                .Select(x => new CarsSaaberIndexViewModel
                {
                    Id = x.Id,
                    Price = x.Price,
                    Brand = x.Brand,
                    Model = x.Model,
                    Year = x.Year,
                    Color = x.Color,
                    Discount = x.Discount,
                });

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarsSaaberDetailsViewModel();

            vm.Id = car.Id;
            vm.Price = car.Price;
            vm.Brand = car.Brand;
            vm.Model = car.Model;
            vm.Year = car.Year;
            vm.Color = car.Color;
            vm.Discount = car.Discount;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarsSaaberCreateUpdateViewModel car = new CarsSaaberCreateUpdateViewModel();

            return View("CreateUpdate", car);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarsSaaberCreateUpdateViewModel vm)
        {
            var dto = new CarsDto()
            {
                Id = vm.Id,
                Price = vm.Price,
                Brand = vm.Brand,
                Model = vm.Model,
                Year = vm.Year,
                Color = vm.Color,
                Discount = vm.Discount,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };

            var result = await _carServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarsSaaberCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.Price = car.Price;
            vm.Brand = car.Brand;
            vm.Model = car.Model;
            vm.Year = car.Year;
            vm.Color = car.Color;
            vm.Discount = car.Discount;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarsSaaberCreateUpdateViewModel vm)
        {
            var dto = new CarsDto()
            {
                Id = vm.Id,
                Price = vm.Price,
                Brand = vm.Brand,
                Model = vm.Model,
                Year = vm.Year,
                Color = vm.Color,
                Discount = vm.Discount,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
            };

            var result = await _carServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarsSaaberDeleteViewModel();

            vm.Id = car.Id;
            vm.Price = car.Price;
            vm.Brand = car.Brand;
            vm.Model = car.Model;
            vm.Year = car.Year;
            vm.Color = car.Color;
            vm.Discount = car.Discount;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carServices.Delete(id);

            if (carId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
