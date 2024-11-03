using Microsoft.EntityFrameworkCore;
using PaymentSystem.Enums;
using PaymentSystem.Models;
using PaymentSystem.Models.ContractModels;
using PaymentSystem.Models.ProductModels;

namespace PaymentSystem.Context;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Software> Softwares { get; set; }
    public DbSet<SoftwareDiscount> SoftwareDiscount { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<User> Users { get; set; }
    
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>().HasData(new List<Client>()
        {
            new()
            {
                ClientId = 1,
                Address = "Wrzosowa 1",
                Email = "jankowalski@gmail.com",
                PhoneNumber = "511111111",
                ClientType = ClientType.IndividualClient,
                FirstName = "Jan",
                LastName = "Kowalski",
                Pesel = "01010101010",
                IsDeleted = false
            },
            new()
            {
                ClientId = 2,
                Address = "Różana 3",
                Email = "firma1@op.pl",
                PhoneNumber = "000000000",
                ClientType = ClientType.CompanyClient,
                CompanyName = "Firma1",
                KrsNumber = "1111111111"
            },
        });

        modelBuilder.Entity<Contract>().HasData(new List<Contract>()
        {
            new()
            {
                ContractId = 1,
                ClientId = 1,
                SoftwareId = 1,
                DateFrom = DateTime.Parse("20/10/2024"),
                DateTo = DateTime.Parse("10/11/2024"),
                MaintenanceYears = 3
            }
        });

        modelBuilder.Entity<Software>().HasMany(s => s.SoftwareDiscounts).WithOne(sd => sd.Software)
            .HasForeignKey(sd => sd.SoftwareId);

        modelBuilder.Entity<Software>().HasData(new List<Software>()
        {
            new()
            {
                SoftwareId = 1,
                Name = "PhotoEditor Pro",
                Description = "Advanced photo editing software with AI features.",
                CurrentVersion = "3.2.1",
                Category = "Graphics",
                Price = 500.00m,
                
            },
            new()
            {
                SoftwareId = 2,
                Name = "CodeMaster IDE",
                Description = "Integrated Development Environment for professional developers.",
                CurrentVersion = "2.5.0",
                Category = "Development",
                Price = 1000.00m,
            }
        });

        modelBuilder.Entity<SoftwareDiscount>().HasData(new List<SoftwareDiscount>()
        {
            new (){
                SoftwareDiscountId = 201,
                DiscountName = "Summer Discount",
                DiscountRate = 12m,
                DateFrom = DateTime.Parse("2024-06-01T00:00:00"),
                DateTo = DateTime.Parse("2024-06-30T23:59:59"),
                SoftwareId = 2
            },
            new ()
            {
                SoftwareDiscountId = 101,
                DiscountName = "Black Friday Sale",
                DiscountRate = 10m,
                DateFrom = DateTime.Parse("2023-11-24T00:00:00"),
                DateTo = DateTime.Parse("2023-11-30T23:59:59"),
                SoftwareId = 1
            },
            new()
            {
                SoftwareDiscountId = 102,
                DiscountName = "Spring Promotion",
                DiscountRate = 15m,
                DateFrom = DateTime.Parse("2024-03-01T00:00:00"),
                DateTo = DateTime.Parse("2024-03-31T23:59:59"),
                SoftwareId = 1
            }
        });
    }
}