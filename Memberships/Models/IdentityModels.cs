using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Memberships.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Memberships.Entities;
using System;

namespace Memberships.Models
{
    // È possibile aggiungere dati del profilo per l'utente aggiungendo altre proprietà alla classe ApplicationUser. Per altre informazioni, vedere https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        // additional fileds
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public DateTime Registered { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenere presente che il valore di authenticationType deve corrispondere a quello definito in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Aggiungere qui i reclami utente personalizzati
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Section> Sections { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductLinkText> ProductLinkTexts { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<SubscriptionProduct> SubscriptionProducts { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        
    }
}