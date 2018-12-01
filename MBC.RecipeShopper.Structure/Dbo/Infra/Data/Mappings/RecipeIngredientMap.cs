using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Infra.Data.Mappings.RecipeIngredient {
    
    
    public class RecipeIngredientMap : IEntityTypeConfiguration<RecipeIngredientInfo> {
        
        public void Configure(EntityTypeBuilder<RecipeIngredientInfo> builder) {
			builder.ToTable("RecipeIngredient", "Dbo");
			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.IngredientId);
			builder.Property(x => x.AmountTypeId);
			builder.Property(x => x.Amount);
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Ingredient).WithMany(x => x.RecipeIngredients).HasForeignKey(x => x.IngredientId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(x => x.AmountType).WithMany(x => x.RecipeIngredients).HasForeignKey(x => x.AmountTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
