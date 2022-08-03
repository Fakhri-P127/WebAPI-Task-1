using Backend_WebAPI_Task1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebAPI_Task1.DAL.Configurations
{
    public class VideoGameConfig : IEntityTypeConfiguration<VideoGame>
    {
        public void Configure(EntityTypeBuilder<VideoGame> builder)
        {
            builder.Property(v => v.Company).HasMaxLength(35).IsRequired();
            builder.Property(v => v.Name).HasMaxLength(35).IsRequired();
            builder.Property(v => v.Price).HasColumnType("decimal(9,2)").IsRequired();
            builder.Property(v => v.IsVisible).HasDefaultValue(true);
        }
    }
}
