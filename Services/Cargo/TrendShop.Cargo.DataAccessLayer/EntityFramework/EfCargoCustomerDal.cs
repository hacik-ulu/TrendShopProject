﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendShop.Cargo.DataAccessLayer.Abstract;
using TrendShop.Cargo.DataAccessLayer.Concrete;
using TrendShop.Cargo.DataAccessLayer.Repositories;
using TrendShop.Cargo.EntityLayer.Concrete;

namespace TrendShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
        }
    }
}