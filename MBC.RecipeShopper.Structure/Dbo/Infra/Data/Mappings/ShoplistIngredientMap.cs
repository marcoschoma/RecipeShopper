using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Infra.Data.Mappings.ShoplistIngredient {
    
    
    public class ShoplistIngredientMap : IEntityTypeConfiguration<ShoplistIngredientInfo> {
        
        public void Configure(EntityTypeBuilder<ShoplistIngredientInfo> builder) {
			builder.ToTable("ShoplistIngredient", "Dbo");
			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.ShoplistId);
			builder.Property(x => x.IngredientId);
			builder.Property(x => x.AmountTypeId);
			builder.Property(x => x.Amount);
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Shoplist).WithMany(x => x.ShoplistIngredients).HasForeignKey(x => x.ShoplistId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(x => x.Ingredient).WithMany(x => x.ShoplistIngredients).HasForeignKey(x => x.IngredientId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(x => x.AmountType).WithMany(x => x.ShoplistIngredients).HasForeignKey(x => x.AmountTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
