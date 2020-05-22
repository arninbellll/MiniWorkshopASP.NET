namespace MiniWS.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MiniWS.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class AppDb : IdentityDbContext<ApplicationUser>
    {
    
        public static AppDb Create()
        {
            return new AppDb();
        }
        public AppDb()
            : base("name=AppDb3")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Cart> Carts { get; set; }
      



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public System.Data.Entity.DbSet<MiniWS.Models.OrderDetail> OrderDetails { get; set; }
    }
}
