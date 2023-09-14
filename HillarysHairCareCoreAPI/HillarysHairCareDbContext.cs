using HillarysHairCareCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HillarysHairCareCoreAPI
{
    public class HillarysHairCareDbContext : DbContext
    {
        public DbSet<Stylist> Stylists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<AppointmentService> AppointmentServices { get; set; }

        public HillarysHairCareDbContext(DbContextOptions<HillarysHairCareDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stylist>().HasData(new Stylist[]
            {
                new Stylist {Id = 1, FirstName = "George", LastName = "Hamilton"},
                new Stylist {Id = 2, FirstName = "Alex", LastName = "Jefferson"},
                new Stylist {Id = 3, FirstName = "Bill", LastName = "Kennedy"},
            });
            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer {Id = 1, FirstName = "Zephyr", LastName = "Evergreen"},
                new Customer {Id = 2, FirstName = "Seraphina", LastName = "Nightshade"},
                new Customer {Id = 3, FirstName = "Orion", LastName = "Thunderstruck"},
                new Customer {Id = 4, FirstName = "Azura", LastName = "Starfall"},
                new Customer {Id = 5, FirstName = "Caspian", LastName = "Moonshadow"},
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment[]
            {
                new Appointment{Id = 1, StylistId = 3, CustomerId = 1, Date = new DateTime(2023,9,16,11,0,0)},
                new Appointment{Id = 2, StylistId = 1, CustomerId = 4, Date = new DateTime(2023,9,16,12,0,0)},
                new Appointment{Id = 3, StylistId = 2, CustomerId = 5, Date = new DateTime(2023,9,16,13,0,0)}
            });
            modelBuilder.Entity<Service>().HasData(new Service[]
            {
                new Service{Id= 1, Name = "Haircut - Long", Cost = 50.00M},
                new Service{Id= 2, Name = "Haircut - Short", Cost = 40.00M},
                new Service{Id= 3, Name = "Shampoo and Blowout", Cost = 35.00M },
                new Service{Id= 4, Name = "Hair Color - Single Process", Cost = 65.00M },
                new Service{Id= 5, Name = "Bread Trim", Cost = 35.00M }
            });
            modelBuilder.Entity<AppointmentService>().HasData(new AppointmentService[]
            {
                new AppointmentService{Id = 1, AppointmentId = 1, ServiceId = 2},
                new AppointmentService{Id = 2, AppointmentId = 1, ServiceId = 4},
                new AppointmentService{Id = 3, AppointmentId = 2, ServiceId = 1},
                new AppointmentService{Id = 4, AppointmentId = 2, ServiceId = 3},
                new AppointmentService{Id = 5, AppointmentId = 3, ServiceId = 5}
            });
        }

    }
}
