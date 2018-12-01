using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Infra.Data.Mappings.Recipe {
    
    
    public class RecipeMap : IEntityTypeConfiguration<RecipeInfo> {
        
        public void Configure(EntityTypeBuilder<RecipeInfo> builder) {
			builder.ToTable("Recipe", "Dbo");
			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.Name).HasMaxLength(100);
			builder.Property(x => x.Steps).HasMaxLength(-1);
			builder.HasKey(x => x.Id);
        }
    }
}
