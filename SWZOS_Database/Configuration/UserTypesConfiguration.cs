using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Configuration
{
    class UserTypesConfiguration: IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("USER_TYPES");

            builder.Property(e => e.Id)
                .HasColumnName("USER_TYPE_ID")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .IsRequired();

            builder.HasMany(e => e.Users)
                .WithOne(u => u.UserType)
                .HasForeignKey(u => u.UserTypeId);
        }
    }
}
