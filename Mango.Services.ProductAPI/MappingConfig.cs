﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mango.Services.ProductAPI.DBContexts.Models;

namespace Mango.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => 
            { 
                config.CreateMap<ProductDto, Product>(); 
                config.CreateMap<Product, ProductDto>(); 
            });
            return mappingConfig;
        }
    }
}
