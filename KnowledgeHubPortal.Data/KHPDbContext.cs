using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.Data
{
    internal class KHPDbContext:DbContext //this context object must not be accessible outside DAL
    {
        //map to db
        public KHPDbContext() { }
        public KHPDbContext(DbContextOptions<KHPDbContext>options):base(options)
        {
            //configuartion through mvc /web api -(connection string in config file on client side)
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=KHPDb2024;Integrated Security=True;Encrypt=True");
            }
        }
        //map to tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
