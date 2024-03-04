using AdaTech.EncurtadorDeLinks.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

public class EncurtadorLinksContext : DbContext
{
    public DbSet<Link> Links { get; set; }
    public EncurtadorLinksContext(DbContextOptions options) : base(options)
    {     
    }
}