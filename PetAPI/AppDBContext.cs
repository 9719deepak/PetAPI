namespace PetAPI
{
    using Microsoft.EntityFrameworkCore;
    using PetAPI.Controllers;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PetModel> Pets { get; set; }
    }

}
