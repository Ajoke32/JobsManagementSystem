using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.ApplicationContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Job> Jobs { get; set; }
}