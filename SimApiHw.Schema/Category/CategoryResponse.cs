using SimApiHw.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApiHw.Schema
{
    public class CategoryResponse
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsValid { get; set; }
        public List<ProductResponse> Products { get; set; }
    }
}
