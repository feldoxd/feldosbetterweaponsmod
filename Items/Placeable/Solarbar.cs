using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Feldosbetterweaponsmod.Tiles;

namespace Feldosbetterweaponsmod.Items.Placeable
{
	public class Solarbar : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Solar bar");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 9999;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.rare = ItemRarityID.Cyan;
			Item.value = Item.buyPrice(gold: 8);
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<PlacedSolarbar>();
			Item.placeStyle = 0;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.LunarBar)
			.AddIngredient(ItemID.FragmentSolar, 2)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}
	}
}