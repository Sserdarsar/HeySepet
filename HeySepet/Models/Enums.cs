namespace HeySepet.Models
{
    // Siparişin geçebileceği durumlar. Veritabanında sayı olarak (0, 1, 2...) saklanır.
    public enum OrderStatus
    {
        New = 0,        // Yeni geldi
        Preparing = 1,  // Mutfak hazırlıyor
        Ready = 2,      // Hazır, garson bekliyor
        Delivered = 3,  // Masaya teslim edildi
        Cancelled = 4   // İptal edildi
    }

    // Siparişin nereden geldiği. Şimdilik sadece Table kullanılacak,
    // diğerleri 4. katmandaki (ortak sepet) platform simülasyonu için.
    public enum OrderSource
    {
        Table = 0,
        Yemeksepeti = 1,
        Getir = 2,
        Trendyol = 3
    }
}
