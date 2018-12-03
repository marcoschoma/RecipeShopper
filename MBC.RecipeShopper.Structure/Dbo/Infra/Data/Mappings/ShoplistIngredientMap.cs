using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Dbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Infra.Data.Mappings.ShoplistIngredient {
    
    
    public class ShoplistIngredientMap : IEntityTypeConfiguration<ShoplistIngredientInfo> {
        
        public void Configure(EntityTypeBuilder<ShoplistIngredientInfo> builder) {
			builder.ToTable("ShoplistIngredient", "Dbo");
			builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.ShoplistId).HasColumnName("ShoplistId");
            builder.Property(x => x.IngredientId).HasColumnName("IngredientId");
            builder.Property(x => x.AmountTypeId).HasColumnName("AmountTypeId");
            builder.Property(x => x.Amount).HasColumnName("Amount");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Shoplist).WithMany(x => x.ShoplistsIngredients).HasForeignKey(x => x.ShoplistId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(x => x.Ingredient).WithMany(x => x.ShoplistsIngredients).HasForeignKey(x => x.IngredientId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(x => x.AmountType).WithMany(x => x.ShoplistsIngredients).HasForeignKey(x => x.AmountTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
