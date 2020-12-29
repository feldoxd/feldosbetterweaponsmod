using Terraria.ModLoader;
using Terraria.ID;

namespace Feldosbetterweaponsmod.Items.Placeable
{
	public class Covidbinus : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Box (koronavirus dam si gabrinus)");
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.Covidbinus>();
			item.width = 24;
			item.height = 24;
			item.rare = -12;
			item.value = 100000;
			item.accessory = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddIngredient(ItemID.Ale, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}