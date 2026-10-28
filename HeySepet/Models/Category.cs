using System.ComponentModel.DataAnnotations;

namespace HeySepet.Models
{
    // Menü kategorisi: Ana yemekler, İçecekler, Tatlılar...
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = "";

        // Menüde hangi sırayla görüneceği (küçük olan önce)
        public int DisplayOrder { get; set; }

        // Bu kategorideki ürünler (bire-çok ilişki)
        public List<MenuItem> MenuItems { get; set; } = new();
    }
}
