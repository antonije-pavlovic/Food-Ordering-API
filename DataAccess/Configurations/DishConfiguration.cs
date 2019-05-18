using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.Property(d => d.Price)
                 .IsRequired();
            builder.Property(d => d.Title)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(d => d.Serving)
                .IsRequired();
            builder.Property(d => d.Ingredients)
                .IsRequired();
            builder.Property(d => d.CreatedtAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
