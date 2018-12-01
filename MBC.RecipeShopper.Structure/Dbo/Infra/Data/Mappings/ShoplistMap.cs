using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Infra.Data.Mappings.Shoplist {
    
    
    public class ShoplistMap : IEntityTypeConfiguration<ShoplistInfo> {
        
        public void Configure(EntityTypeBuilder<ShoplistInfo> builder) {
			builder.ToTable("Shoplist", "Dbo");
			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.CreationDate).IsRequired();
			builder.HasKey(x => x.Id);
        }
    }
}
