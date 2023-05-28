using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimApiHw.Data;
using SimApiHw.Data.Context;
using SimApiHw.Schema;
using static Dapper.SqlMapper;

namespace SimApiHw.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private SimDbContext context;
        private readonly IProductRepository repository;
        private IMapper mapper;
        public ProductController(IMapper mapper, IProductRepository repository, SimDbContext context)
        {
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll() 
        {
            var list=repository.GetAll();
            var mapped=mapper.Map<List<ProductResponse>>(list);
            return Ok(mapped);
        }

        [HttpGet("{CategoryId}")]
        public ActionResult<List<Product>> Get(int CategoryId)
        {
            var products=repository.GetByCategoryId(CategoryId);
            return products;
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> Create(ProductRequest request)
        {
            var category = await context.Category.FindAsync(request.CategoryId);
            if (category == null)
                return NotFound();
           
            var product = new Product
            {
                Name = request.Name,
                Url=request.Url,
                Price=request.Price,
                Category = category,
                CreatedAt = DateTime.UtcNow,
                CreatedBy=Environment.MachineName
            };
         
            context.Product.Add(product);
            await context.SaveChangesAsync();
            return Get(product.CategoryId);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductRequest request)
        {
            var entity = repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }

            var product = mapper.Map<ProductRequest, Product>(request);
            product.Id = id;

            // Sadece product özelliklerini güncelle
            entity.Name = product.Name;
            entity.Url = product.Url;
            //entity.Tag = product.Tag;

            repository.Update(entity);
            repository.Complete();

            return Ok();
        }


        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            repository.DeleteById(id);
            repository.Complete();
            return Ok();
        }

    }

    
}
