using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Configuration
{
    class EquipmentConfiguration: IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("EQUIPMENT");

            builder.Property(e => e.Id)
                .HasColumnName("ITEM_ID")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Quantity)
                .HasColumnName("QUANTITY")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(4000);
        }
    }
}
