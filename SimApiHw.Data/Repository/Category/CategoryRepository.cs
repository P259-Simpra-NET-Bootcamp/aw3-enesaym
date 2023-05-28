using Microsoft.EntityFrameworkCore;
using SimApiHw.Data.Context;
using SimApiHw.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApiHw.Data;

public class CategoryRepository : GenericRepository<Category>,ICategoryRepository 
{

    public CategoryRepository(SimDbContext context) : base(context)
    {

    }

    public List<Category> GetAllWithInclude()
    {
        var list = dbContext.Set<Category>()
           .Where(x => x.IsValid)
           .Include(x => x.Products)
           .ToList();
        return list;
    }
}
