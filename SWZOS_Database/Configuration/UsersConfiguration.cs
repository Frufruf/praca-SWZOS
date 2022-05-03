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
            builder.HasKey(e => e.UserId);

            builder.ToTable("USERS");

            builder.Property(e => e.UserId)
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
                .HasColumnName("EMAIL_ADDRESS")
                .IsRequired();

            builder.Property(e => e.UserTypeId)
                .HasColumnName("USER_TYPE_ID")
                .IsRequired();

            builder.Property(e => e.PasswordSalt)
                .HasColumnName("PASSWORD_SALT")
                .IsRequired();

            builder.Property(e => e.PasswordHash)
                .HasColumnName("PASSWORD_HASH")
                .IsRequired();

            builder.Property(e => e.PasswordExpirationDate)
                .HasColumnName("PASSWORD_EXPIRATION_DATE");

            builder.Property(e => e.ActiveFlag)
                .HasColumnName("ACTIVE_FLAG")
                .IsRequired();

            builder.Property(e => e.DeletedFlag)
                .HasColumnName("DELETED_FLAG")
                .IsRequired();

            builder.Property(e => e.PasswordTemp)
                .HasColumnName("PASSWORD_TEMP")
                .IsRequired();

            builder.HasMany(e => e.Reservations)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder.HasOne<BlackList>(e => e.BlackList)
                .WithOne(b => b.User)
                .HasForeignKey<BlackList>(b => b.UserId);
        }
    }
}
