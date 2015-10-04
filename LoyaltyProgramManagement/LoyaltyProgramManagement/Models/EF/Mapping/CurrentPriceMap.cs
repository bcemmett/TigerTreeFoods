using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LoyaltyProgramManagement.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductId);

            // Properties
            this.Property(t => t.Barcode)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.TillDescription)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Barcode).HasColumnName("Barcode");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.RegularPrice).HasColumnName("RegularPrice");
            this.Property(t => t.OfferPrice).HasColumnName("OfferPrice");
            this.Property(t => t.TillDescription).HasColumnName("TillDescription");
            this.Property(t => t.Image).HasColumnName("Image");
        }
    }
}
