using Microsoft.EntityFrameworkCore;
using SiteMVC.Models;

namespace SiteMVC.Data;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
    }
    
    public DbSet<ContactModel> Contacts { get; set; }
    
    public DbSet<UserModel> Users { get; set; }
}