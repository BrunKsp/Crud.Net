using Microsoft.EntityFrameworkCore;
using CrudApi.Models;

namespace CrudApi.Data
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext(DbContextOptions<ProdutosContext> options)
            : base(options)
        {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        IConfiguration configuration = new  ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json",false , true)
        .Build();
        
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        
        }
        public DbSet <Produtos> Produtos {get;set;}
    }
}