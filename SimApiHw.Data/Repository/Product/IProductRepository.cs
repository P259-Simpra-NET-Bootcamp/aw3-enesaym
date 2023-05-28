using SimApiHw.Data.Context;
using SimApiHw.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApiHw.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public List<Product> GetByCategoryId(int CategoryId);
    }
}
