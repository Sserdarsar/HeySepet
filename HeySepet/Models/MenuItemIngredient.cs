namespace HeySepet.Models
{
    // Ara tablo: hangi ürün hangi malzemeyi içeriyor.
    // Bir ürünün birden çok malzemesi, bir malzemenin birden çok ürünü olabilir (çoka-çok).
    // Birincil anahtar (MenuItemId + IngredientId) ApplicationDbContext içinde tanımlanıyor.
    public class MenuItemIngredient
    {
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }

        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
    }
}
