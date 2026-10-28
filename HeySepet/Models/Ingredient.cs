using System.ComponentModel.DataAnnotations;

namespace HeySepet.Models
{
    // Malzeme: Pilav, Bulgur, Ayran, Lavaş...
    public class Ingredient
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = "";

        // false olursa ("Pilav bitti") bu malzemeyi içeren bütün ürünler satıştan düşer.
        public bool IsAvailable { get; set; } = true;

        public List<MenuItemIngredient> MenuItemIngredients { get; set; } = new();
    }
}
