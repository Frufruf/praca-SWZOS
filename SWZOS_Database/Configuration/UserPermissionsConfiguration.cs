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
    class UserPermissionsConfiguration: IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.HasKey(e => new { e.UserId, e.PermissionId });

            builder.ToTable("USER_PERMISSIONS");

            builder.Property(e => e.UserId)
                .HasColumnName("USER_ID")
                .IsRequired();

            builder.Property(e => e.PermissionId)
                .HasColumnName("PERMISSION_ID")
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(u => u.UserPermissions)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Permission)
                .WithMany(u => u.UserPermissions)
                .HasForeignKey(e => e.PermissionId);
        }
    }
}
