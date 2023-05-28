using Microsoft.EntityFrameworkCore;
using SimApiHw.Data.Context;
using SimApiHw.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApiHw.Data;

public class ProductRepository: GenericRepository<Product>,IProductRepository
{
    public ProductRepository(SimDbContext context) :base(context)
    {
        
    }

    public List<Product> GetByCategoryId(int CategoryId)
    {
        var products = dbContext.Product
               .Where(c => c.CategoryId == CategoryId)
               .Include(c => c.Category)
               .ToList();
        return products;
    }
}
