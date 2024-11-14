using CarServiceBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceBooking.Data
{
    public class CarServiceContext : DbContext
    {
        public CarServiceContext(DbContextOptions<CarServiceContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        

    }
}
