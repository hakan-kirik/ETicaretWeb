﻿using ETicaretApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Repositories.ProductRepo
{
    public interface IProductWriteRepository:IWriteRepository<Product>
    {
    }
}
