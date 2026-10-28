using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HeySepet.Models
{
    // Siparişteki bir satır: "2 x Ayran"
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }

        [Range(1, 50)]
        public int Quantity { get; set; }

        // Sipariş anındaki birim fiyat. Menüdeki fiyat sonradan değişirse
        // eski siparişlerin tutarı değişmesin diye ayrıca saklanır.
        // Bu değer her zaman SUNUCUDA, veritabanındaki fiyattan doldurulur;
        // tarayıcıdan gelen fiyata asla güvenilmez.
        [Precision(10, 2)]
        public decimal UnitPrice { get; set; }
    }
}
