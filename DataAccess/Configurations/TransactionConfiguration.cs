using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(t => t.Amount)
                .IsRequired();
            builder.Property(t => t.Type)
                .IsRequired();
            builder.Property(t => t.CreatedtAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
