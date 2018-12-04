using MBC.RecipeShopper.Dbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBC.RecipeShopper.Dbo.Infra.Data.Mappings.RecipeIngredient
{
    public class RecipeIngredientMap : IEntityTypeConfiguration<RecipeIngredientInfo> {
        
        public void Configure(EntityTypeBuilder<RecipeIngredientInfo> builder) {
			builder.ToTable("RecipeIngredient", "Dbo");
			builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
			builder.Property(x => x.IngredientId).HasColumnName("IngredientId");
			builder.Property(x => x.AmountTypeId).HasColumnName("AmountTypeId");
            builder.Property(x => x.Amount).HasColumnName("Amount");
            builder.Property(x => x.RecipeId).HasColumnName("RecipeId");
			builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Recipe).WithMany(x => x.RecipeIngredients).HasForeignKey(x => x.RecipeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Ingredient).WithMany(x => x.RecipesIngredients).HasForeignKey(x => x.IngredientId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(x => x.AmountType).WithMany(x => x.RecipesIngredients).HasForeignKey(x => x.AmountTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
