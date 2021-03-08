using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Tiles;

namespace Feldosbetterweaponsmod.Items.Placeable
{
	public class Nebulabar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula bar");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.maxStack = 9999;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.value = Item.buyPrice(gold: 8);
			item.rare = ItemRarityID.Cyan;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<PlacedNebulabar>();
			item.placeStyle = 0;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar);
			recipe.AddIngredient(ItemID.FragmentNebula, 2);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}