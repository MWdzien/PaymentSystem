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
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    
    

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

        modelBuilder.Entity<Software>().HasData(new List<Software>()
        {
            new()
            {
                SoftwareId = 1,
                Name = "Software1",
                Description = "Description descriptiopn descritortopn",
                Category = "Business",
                CurrentVersion = "1.0",
                Price = 10000
            }
        });
    }
}