using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.Price).HasColumnType("decimal(18,2)");
            builder.Property(s => s.PictureUrl).IsRequired();
            builder.HasOne(s => s.ProductBrand).WithMany().HasForeignKey(s => s.ProductBrandId);
            builder.HasOne(s => s.ProductType).WithMany().HasForeignKey(s => s.ProductTypeId);
            
        }
    }
}