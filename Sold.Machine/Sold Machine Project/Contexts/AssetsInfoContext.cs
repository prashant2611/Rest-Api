using Microsoft.EntityFrameworkCore;
using Sold.Machine.Service;
using Sold_Machine_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sold_Machine_Project.Contexts
{
    public class AssetsInfoContext:DbContext
    {
        public DbSet<Assets> Assets { get; set; }
        private FileReader _data = new FileReader("matrix.csv");
        private IEnumerable<AssetInfo> _assets;

        public AssetsInfoContext(DbContextOptions<AssetsInfoContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _assets = _data.ReadFileContent();
            modelBuilder.Entity<Assets>().HasData(_assets);
            base.OnModelCreating(modelBuilder);
        }

    }
}
