using System.ComponentModel.DataAnnotations;

namespace HeySepet.Models
{
    // Restorandaki masa. Adı "Table" değil "DiningTable", çünkü TABLE SQL'de ayrılmış bir kelime.
    public class DiningTable
    {
        public int Id { get; set; }

        // Masanın üzerinde yazan numara (müşteriye görünen)
        public int Number { get; set; }

        // QR'daki adreste kullanılan rastgele kod: /m/x7K2pQ
        // Masa numarası yerine bu kullanılır, böylece adresi değiştirip başka masaya sipariş verilemez.
        // Benzersiz olması ApplicationDbContext içinde tanımlanıyor.
        [Required, StringLength(16)]
        public string Code { get; set; } = "";

        public List<Order> Orders { get; set; } = new();
    }
}
