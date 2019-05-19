using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .HasMaxLength(25)
                .IsRequired();
            builder.Property(u => u.LastName)
                .HasMaxLength(25)
                .IsRequired();
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(u => u.Password)
                .IsRequired();
            builder.Property(u => u.IsDeleted)
                .HasDefaultValue(0);
            builder.Property(u => u.CreatedtAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
