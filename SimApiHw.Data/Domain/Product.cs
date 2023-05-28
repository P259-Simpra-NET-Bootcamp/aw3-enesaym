using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SimApiHw.Base.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimApiHw.Data;

[Table("Product", Schema = "dbo")]
public class Product : BaseModel
{

    public string Name { get; set; }
    public string Url { get; set; }
    public int Price { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
   
    public Category Category { get; set; }


}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
      
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Url).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.Price).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.CategoryId).IsRequired(true);

        builder.HasIndex(x => x.CategoryId);


    }
}
