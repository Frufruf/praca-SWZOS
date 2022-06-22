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
    class BlackListStatusConfiguration: IEntityTypeConfiguration<BlackListStatus>
    {
        public void Configure(EntityTypeBuilder<BlackListStatus> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("BLACK_LIST_STATUS");

            builder.Property(e => e.Id)
                .HasColumnName("BLACK_LIST_STATUS_ID")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .IsRequired();

            builder.HasMany(e => e.BlackLists)
                .WithOne(b => b.BlackListStatus)
                .HasForeignKey(b => b.StatusId);
        }
    }
}
