using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBEntityContext: DbContext
    {
        public DBEntityContext():base("name=defaultConnection")
        {
            Database.SetInitializer<DBEntityContext>(new DbInitializer());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Model.Action> Actions { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Projected> Projecteds { get; set; }
        public DbSet<Baogia> Baogias { get; set; }
            
    }

}
