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
    class PermissionsConfiguration: IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(e => e.PermissionId);

            builder.ToTable("PERMISSIONS");

            builder.Property(e => e.PermissionId)
                .HasColumnName("PERMISSION_ID")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(4000);

            builder.Property(e => e.DeletedFlag)
                .HasColumnName("DELETED_FLAG")
                .IsRequired();
        }

    }
}
