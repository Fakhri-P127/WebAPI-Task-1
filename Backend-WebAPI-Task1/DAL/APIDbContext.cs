using Backend_WebAPI_Task1.DAL.Configurations;
using Backend_WebAPI_Task1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebAPI_Task1.DAL
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Gameshop> Gameshops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VideoGameConfig());
            modelBuilder.ApplyConfiguration(new GameshopConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
