using Backend_WebAPI_Task1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebAPI_Task1.DAL.Configurations
{
    public class GameshopConfig : IEntityTypeConfiguration<Gameshop>
    {
        public void Configure(EntityTypeBuilder<Gameshop> builder)
        {
            builder.Property(g => g.Title).IsRequired().HasMaxLength(50);
            builder.Property(g => g.Address).IsRequired().HasMaxLength(50);
            builder.Property(g => g.PriceRange).HasDefaultValue(null);
        }
    }
}
