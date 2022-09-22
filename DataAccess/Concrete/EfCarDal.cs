using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapCarContext context = new ReCapCarContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = ca.CarId,
                                 CarName = ca.CarName,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
