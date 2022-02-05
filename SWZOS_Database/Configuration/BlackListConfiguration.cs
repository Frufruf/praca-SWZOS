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
    class BlackListConfiguration: IEntityTypeConfiguration<BlackList>
    {
        public void Configure(EntityTypeBuilder<BlackList> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("BLACK_LIST");

            builder.Property(e => e.Id)
                .HasColumnName("BLACK_LIST_ID")
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName("USER_ID")
                .IsRequired();

            builder.Property(e => e.Reason)
                .HasColumnName("REASON")
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(e => e.StatusId)
                .HasColumnName("STATUS")
                .IsRequired();

        }
    }
}
