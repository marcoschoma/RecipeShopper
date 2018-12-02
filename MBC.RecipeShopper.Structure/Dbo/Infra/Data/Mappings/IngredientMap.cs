using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Dbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Infra.Data.Mappings.Ingredient {
    
    
    public class IngredientMap : IEntityTypeConfiguration<IngredientInfo> {
        
        public void Configure(EntityTypeBuilder<IngredientInfo> builder) {
			builder.ToTable("Ingredient", "Dbo");
			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.Description).HasMaxLength(100);
			builder.HasKey(x => x.Id);
        }
    }
}
