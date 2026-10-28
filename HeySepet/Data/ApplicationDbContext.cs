using HeySepet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeySepet.Data
{
    // IdentityDbContext: giriş sistemi (kullanıcılar, roller) tablolarını hazır getirir.
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Her DbSet veritabanında bir tabloya karşılık gelir.
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MenuItemIngredient> MenuItemIngredients { get; set; }
        public DbSet<DiningTable> DiningTables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Identity tabloları için bu satır şart, silmeyin.
            base.OnModelCreating(builder);

            // Ara tablonun birincil anahtarı iki sütundan oluşuyor:
            // aynı ürüne aynı malzeme iki kez eklenemez.
            builder.Entity<MenuItemIngredient>()
                .HasKey(mi => new { mi.MenuItemId, mi.IngredientId });

            // QR kodu benzersiz olmalı.
            builder.Entity<DiningTable>()
                .HasIndex(t => t.Code)
                .IsUnique();

            // Masa numarası da benzersiz olmalı.
            builder.Entity<DiningTable>()
                .HasIndex(t => t.Number)
                .IsUnique();

            // Aynı platform siparişi iki kez kaydedilemez.
            // Filtre: masa siparişlerinde ExternalOrderId boş olduğu için onları kurala dahil etme.
            builder.Entity<Order>()
                .HasIndex(o => new { o.Source, o.ExternalOrderId })
                .IsUnique()
                .HasFilter("[ExternalOrderId] IS NOT NULL");

            // Malzeme adı benzersiz olmalı ("Pilav" iki kez eklenemez).
            builder.Entity<Ingredient>()
                .HasIndex(i => i.Name)
                .IsUnique();

            // Siparişte kullanılmış bir ürün silinemesin (geçmiş siparişler bozulmasın).
            // Ürünü menüden kaldırmak için silmek yerine IsManuallyDisabled kullanılır.
            builder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany()
                .HasForeignKey(oi => oi.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
