using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HeySepet.Models
{
    // Menüdeki bir ürün: "Pilav üstü tavuk", "Ayran"...
    public class MenuItem
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = "";

        [StringLength(300)]
        public string? Description { get; set; }

        // Para her zaman decimal ile tutulur (double yuvarlama hatası yapar).
        // Precision(10, 2): toplam 10 basamak, virgülden sonra 2 basamak.
        [Precision(10, 2)]
        [Range(0.01, 100000)]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // Yöneticinin ürünü elle kapatması için.
        // Ürünün satışta olup olmadığı burada SAKLANMAZ, her seferinde hesaplanır:
        // satışta = elle kapatılmamış VE bütün malzemeleri mevcut.
        public bool IsManuallyDisabled { get; set; }

        // Bu ürünün içerdiği malzemeler (çoka-çok ilişki, ara tablo üzerinden)
        public List<MenuItemIngredient> MenuItemIngredients { get; set; } = new();
    }
}
