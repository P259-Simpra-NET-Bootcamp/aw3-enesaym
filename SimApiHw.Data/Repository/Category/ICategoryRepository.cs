using SimApiHw.Data.Repository.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimApiHw.Data;
using Microsoft.EntityFrameworkCore;

namespace SimApiHw.Data
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        public List<Category> GetAllWithInclude();
    }
}
