using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Items
{
	public class Milk : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Milk");
		}

		public override void SetDefaults()
		{
			item.width = 29;
			item.height = 40;
			item.maxStack = 9999;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock);
			recipe.SetResult(this, 999);
			recipe.AddRecipe();
		}*/
	}
}