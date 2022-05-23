using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Feldosbetterweaponsmod.Items.Placeable;

namespace Feldosbetterweaponsmod
{
	public class Feldosbetterweaponsmod : Mod
	{
		public override void Load()
        {

        }

		public override void Unload()
		{

		}

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil bows", new int[]
			{
				ItemID.DemonBow,
				ItemID.TendonBow
			});
			RecipeGroup.RegisterGroup("Feldosbetterweaponsmod:Evilbows", group);
		}
		
		

	}

	public class Recipes : ModSystem
    {

		public override void AddRecipes()
		{
			//solar stuff
			Recipe s1 = Mod.CreateRecipe(ItemID.SolarFlareHelmet, 1);
			s1.AddIngredient(ModContent.ItemType<Solarbar>(), 4);
			s1.AddTile(TileID.LunarCraftingStation);
			s1.Register();
			Recipe s2 = Mod.CreateRecipe(ItemID.SolarFlareBreastplate, 1);
			s2.AddIngredient(ModContent.ItemType<Solarbar>(), 9);
			s2.AddTile(TileID.LunarCraftingStation);
			s2.Register();
			Recipe s3 = Mod.CreateRecipe(ItemID.SolarFlareLeggings, 1);
			s3.AddIngredient(ModContent.ItemType<Solarbar>(), 7);
			s3.AddTile(TileID.LunarCraftingStation);
			s3.Register();
			//vortex stuff
			Recipe v1 = Mod.CreateRecipe(ItemID.VortexHelmet, 1);
			v1.AddIngredient(ModContent.ItemType<Vortexbar>(), 4);
			v1.AddTile(TileID.LunarCraftingStation);
			v1.Register();
			Recipe v2 = Mod.CreateRecipe(ItemID.VortexBreastplate, 1);
			v2.AddIngredient(ModContent.ItemType<Vortexbar>(), 9);
			v2.AddTile(TileID.LunarCraftingStation);
			v2.Register();
			Recipe v3 = Mod.CreateRecipe(ItemID.VortexLeggings, 1);
			v3.AddIngredient(ModContent.ItemType<Vortexbar>(), 7);
			v3.AddTile(TileID.LunarCraftingStation);
			v3.Register();
			//nebula stuff
			Recipe n1 = Mod.CreateRecipe(ItemID.NebulaHelmet, 1);
			n1.AddIngredient(ModContent.ItemType<Nebulabar>(), 4);
			n1.AddTile(TileID.LunarCraftingStation);
			n1.Register();
			Recipe n2 = Mod.CreateRecipe(ItemID.NebulaBreastplate, 1);
			n2.AddIngredient(ModContent.ItemType<Nebulabar>(), 9);
			n2.AddTile(TileID.LunarCraftingStation);
			n2.Register();
			Recipe n3 = Mod.CreateRecipe(ItemID.NebulaLeggings, 1);
			n3.AddIngredient(ModContent.ItemType<Nebulabar>(), 7);
			n3.AddTile(TileID.LunarCraftingStation);
			n3.Register();
			//stardust stuff
			Recipe st1 = Mod.CreateRecipe(ItemID.StardustHelmet, 1);
			st1.AddIngredient(ModContent.ItemType<Stardustbar>(), 4);
			st1.AddTile(TileID.LunarCraftingStation);
			st1.Register();
			Recipe st2 = Mod.CreateRecipe(ItemID.StardustBreastplate, 1);
			st2.AddIngredient(ModContent.ItemType<Stardustbar>(), 9);
			st2.AddTile(TileID.LunarCraftingStation);
			st2.Register();
			Recipe st3 = Mod.CreateRecipe(ItemID.StardustLeggings, 1);
			st3.AddIngredient(ModContent.ItemType<Stardustbar>(), 7);
			st3.AddTile(TileID.LunarCraftingStation);
			st3.Register();
		}


	}

}