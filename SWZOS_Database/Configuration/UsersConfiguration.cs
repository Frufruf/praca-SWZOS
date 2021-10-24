using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Configuration
{
    class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("USERS");

            builder.Property(e => e.Id)
                .HasColumnName("USER_ID")
                .IsRequired();

            builder.Property(e => e.Login)
                .HasColumnName("LOGIN")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Surname)
                .HasColumnName("SURNAME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.PESEL)
                .HasColumnName("PESEL")
                .HasMaxLength(11);

            builder.Property(e => e.PhoneNumber)
                .HasColumnName("PHONE_NUMBER");

            builder.Property(e => e.MailAddress)
                .HasColumnName("EMAIL_ADDRESS");

            builder.Property(e => e.UserTypeId)
                .HasColumnName("USER_TYPE_ID")
                .IsRequired();

            builder.Property(e => e.PasswordSalt)
                .HasColumnName("PASSWORD_SALT");
            //.IsRequired();

            builder.Property(e => e.PasswordHash)
                .HasColumnName("PASSWORD_HASH");
                //.IsRequired();
        }
    }
}
