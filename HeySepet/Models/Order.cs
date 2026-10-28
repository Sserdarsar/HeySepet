using System.ComponentModel.DataAnnotations;

namespace HeySepet.Models
{
    public class Order
    {
        public int Id { get; set; }

        public OrderSource Source { get; set; } = OrderSource.Table;

        // Masa siparişlerinde dolu, platform siparişlerinde (Getir vb.) boş.
        public int? DiningTableId { get; set; }
        public DiningTable? DiningTable { get; set; }

        // Platformdaki sipariş numarası. Masa siparişlerinde boş.
        // (Source + ExternalOrderId) benzersiz: aynı platform siparişi iki kez kaydedilemez.
        [StringLength(50)]
        public string? ExternalOrderId { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.New;

        // Müşteri notu: "soğansız", "sos ayrı"
        [StringLength(200)]
        public string? Note { get; set; }

        // Sunucuda her zaman UTC saklanır, ekranda yerel saate çevrilir.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsPaid { get; set; }

        public List<OrderItem> Items { get; set; } = new();
    }
}
