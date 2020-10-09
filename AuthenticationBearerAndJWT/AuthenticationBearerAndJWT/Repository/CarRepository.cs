using AuthenticationBearerAndJWT.Model;
using System.Collections.Generic;
using System.Linq;

namespace AuthenticationBearerAndJWT.Repository
{
    public static class CarRepository
    {
        private static readonly IList<Car> Cars = new List<Car>()
        {
            new Car
            {
                Id = 1,
                Name = "BMW Serie 3",
                Price = 45000,
                LicensePlate = "ABC1234"
            },
            new Car
            {
                Id = 2,
                Name = "BMW X5",
                Price = 56000,
                LicensePlate = "XYZ9999"
            },
            new Car
            {
                Id = 3,
                Name = "BMW Z4",
                Price = 69000,
                LicensePlate = "AXC5678"
            }
        };

        public static IList<Car> Get() => Cars;

        public static Car Get(int id) => Cars.FirstOrDefault(f => f.Id == id);
    }
}
