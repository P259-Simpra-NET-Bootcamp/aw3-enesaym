using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimApiHw.Data.Context;
using SimApiHw.Data.Repository.Base;
using SimApiHw.Schema;
using SimApiHw.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;

namespace SimApiHw.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategoryRepository repository;
        private IMapper mapper;
        public CategoryController(SimDbContext context, IMapper mapper, ICategoryRepository repository)
        {
            this.repository = repository;

            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = repository.GetAllWithInclude();
            var mapped = mapper.Map<List<Category>, List<CategoryResponse>>(list);
            return Ok(mapped);

        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryRequest request)
        {
            var entity = mapper.Map<CategoryRequest, Category>(request);
            entity.GetType().GetProperty("CreatedAt").SetValue(entity, DateTime.UtcNow);
            entity.GetType().GetProperty("CreatedBy").SetValue(entity, Environment.MachineName);
            repository.Insert(entity);
            repository.Complete();

            return Ok(GetAll());
        }
        [HttpPut("id")]
        public IActionResult Put(int id, [FromBody] CategoryRequest request)
        {          
                var entity = repository.GetById(id);
                if (entity == null)
                {
                    return NotFound();
                }
                var originalProducts = entity.Products;
                mapper.Map(request, entity);
                entity.Id = id;
                entity.Products = originalProducts;
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
