using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Feldosbetterweaponsmod.Items.Placeable;

namespace Feldosbetterweaponsmod
{
	public class Feldosbetterweaponsmod : Mod
	{
		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil bows", new int[]
			{
				ItemID.DemonBow,
				ItemID.TendonBow
			});
			RecipeGroup.RegisterGroup("Feldosbetterweaponsmod:Evilbows", group);
		}
		public override void AddRecipes()
		{
			//solar stuff
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Solarbar>(), 4);
			recipe.SetResult(ItemID.SolarFlareHelmet);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Solarbar>(), 9);
			recipe.SetResult(ItemID.SolarFlareBreastplate);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Solarbar>(), 7);
			recipe.SetResult(ItemID.SolarFlareLeggings);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
			//vortex stuff
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Vortexbar>(), 4);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.VortexHelmet);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Vortexbar>(), 9);
			recipe.SetResult(ItemID.VortexBreastplate);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Vortexbar>(), 7);
			recipe.SetResult(ItemID.VortexLeggings);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
			//nebula stuff
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Nebulabar>(), 4);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.NebulaHelmet);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Nebulabar>(), 9);
			recipe.SetResult(ItemID.NebulaBreastplate);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Nebulabar>(), 7);
			recipe.SetResult(ItemID.NebulaLeggings);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
			//stardust stuff
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Stardustbar>(), 4);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.StardustHelmet);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Stardustbar>(), 9);
			recipe.SetResult(ItemID.StardustBreastplate);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Stardustbar>(), 7);
			recipe.SetResult(ItemID.StardustLeggings);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
		}
	}
}