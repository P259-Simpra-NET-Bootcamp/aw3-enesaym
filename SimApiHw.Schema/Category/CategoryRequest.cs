using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApiHw.Schema
{
    public class CategoryRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Order { get; set; }

        public IEnumerable<ProductRequest> Products { get; set; } = new List<ProductRequest>();
       
        
    }
}
