using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SimApiHw.Base.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SimApiHw.Data;

[Table("Category", Schema = "dbo")]
public class Category :BaseModel
{
        public string Name { get; set; }
        public int? Order { get; set; }
        public bool IsValid { get; set; } = true;
        [JsonIgnore]
        public virtual List<Product> Products { get; set; }


    }

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
            

            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.Order).IsRequired(false);

            builder.HasIndex(x => x.Name).IsUnique(true);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .IsRequired(false);



        }
    }

