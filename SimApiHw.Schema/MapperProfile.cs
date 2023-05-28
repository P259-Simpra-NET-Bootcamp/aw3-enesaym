using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SimApiHw.Data;

namespace SimApiHw.Schema;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Category, CategoryResponse>();
        CreateMap<CategoryRequest, Category>();

        CreateMap<Product, ProductResponse>();
        CreateMap<ProductRequest, Product>();

    }


}
