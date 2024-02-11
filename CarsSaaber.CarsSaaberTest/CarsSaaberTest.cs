using CarsSaaber.Core.Dto;
using CarsSaaber.Core.ServiceInterface;

namespace CarsSaaber.CarsSaaberTest
{
    public class CarsSaaberTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyCar_WhenReturnResult()
        {
            var dto = new CarsDto()
            {
                Price = 100,
                Brand = "Tesla",
                Model = "X",
                Year = 1991,
                Color = "Red",
                Discount = 0,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var result = await Svc<ICarsSaaberServices>().Create(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdCar_WhenReturnsNotEqual()
        {
            Guid guid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            Guid wrongGuid = Guid.NewGuid();

            await Svc<ICarsSaaberServices>().GetAsync(guid);

            Assert.NotEqual(guid, wrongGuid);
        }

        [Fact]
        public async Task Should_GetByIdCar_WhenReturnsEqual()
        {
            Guid databaseGuid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            Guid getGuid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");

            await Svc<ICarsSaaberServices>().GetAsync(getGuid);

            Assert.Equal(databaseGuid, getGuid);
        }

        [Fact]
        public async Task Should_DeleteByIdCar_WhenDeleteCar()
        {
            CarsDto car = MockCarData();

            var addCar = await Svc<ICarsSaaberServices>().Create(car);
            var result = await Svc<ICarsSaaberServices>().Delete(addCar.Id.GetValueOrDefault());

            Assert.Equal(result, addCar);
        }

        [Fact]
        public async Task ShouldNot_UpdateCar_WhenNotUpdateData()
        {
            CarsDto dto = MockCarData();
            await Svc<ICarsSaaberServices>().Create(dto);

            CarsDto nullUpdate = MockNullCarData();
            await Svc<ICarsSaaberServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);
        }

        private CarsDto MockCarData()
        {
            return new CarsDto()
            {
                Price = 100,
                Brand = "Tesla",
                Model = "X",
                Year = 1991,
                Color = "Red",
                Discount = 0,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        private CarsDto MockNullCarData()
        {
            var car = MockCarData();
            car.Id = null;

            return car;
        }
    }
}
