using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Items.Placeable;
using Microsoft.Xna.Framework;
using System;

namespace Feldosbetterweaponsmod
{
	public class Feldosbetterweaponsmod : Mod
	{
        [Obsolete]
        public override void AddRecipeGroups()/* tModPorter Note: Removed. Use ModSystem.AddRecipeGroups */
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil bows", new int[]
			{
				ItemID.DemonBow,
				ItemID.TendonBow
			});
			RecipeGroup.RegisterGroup("Feldosbetterweaponsmod:Evilbows", group);
		}

		public static void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}
	}



	public class Recipes : ModSystem
    {
		public override void AddRecipes()
		{
			//solar stuff
			Recipe s1 = Recipe.Create(ItemID.SolarFlareHelmet, 1);
			s1.AddIngredient(ModContent.ItemType<Solarbar>(), 4);
			s1.AddTile(TileID.LunarCraftingStation);
			s1.Register();
			Recipe s2 = Recipe.Create(ItemID.SolarFlareBreastplate, 1);
			s2.AddIngredient(ModContent.ItemType<Solarbar>(), 9);
			s2.AddTile(TileID.LunarCraftingStation);
			s2.Register();
			Recipe s3 = Recipe.Create(ItemID.SolarFlareLeggings, 1);
			s3.AddIngredient(ModContent.ItemType<Solarbar>(), 7);
			s3.AddTile(TileID.LunarCraftingStation);
			s3.Register();
			//vortex stuff
			Recipe v1 = Recipe.Create(ItemID.VortexHelmet, 1);
			v1.AddIngredient(ModContent.ItemType<Vortexbar>(), 4);
			v1.AddTile(TileID.LunarCraftingStation);
			v1.Register();
			Recipe v2 = Recipe.Create(ItemID.VortexBreastplate, 1);
			v2.AddIngredient(ModContent.ItemType<Vortexbar>(), 9);
			v2.AddTile(TileID.LunarCraftingStation);
			v2.Register();
			Recipe v3 = Recipe.Create(ItemID.VortexLeggings, 1);
			v3.AddIngredient(ModContent.ItemType<Vortexbar>(), 7);
			v3.AddTile(TileID.LunarCraftingStation);
			v3.Register();
			//nebula stuff
			Recipe n1 = Recipe.Create(ItemID.NebulaHelmet, 1);
			n1.AddIngredient(ModContent.ItemType<Nebulabar>(), 4);
			n1.AddTile(TileID.LunarCraftingStation);
			n1.Register();
			Recipe n2 = Recipe.Create(ItemID.NebulaBreastplate, 1);
			n2.AddIngredient(ModContent.ItemType<Nebulabar>(), 9);
			n2.AddTile(TileID.LunarCraftingStation);
			n2.Register();
			Recipe n3 = Recipe.Create(ItemID.NebulaLeggings, 1);
			n3.AddIngredient(ModContent.ItemType<Nebulabar>(), 7);
			n3.AddTile(TileID.LunarCraftingStation);
			n3.Register();
			//stardust stuff
			Recipe st1 = Recipe.Create(ItemID.StardustHelmet, 1);
			st1.AddIngredient(ModContent.ItemType<Stardustbar>(), 4);
			st1.AddTile(TileID.LunarCraftingStation);
			st1.Register();
			Recipe st2 = Recipe.Create(ItemID.StardustBreastplate, 1);
			st2.AddIngredient(ModContent.ItemType<Stardustbar>(), 9);
			st2.AddTile(TileID.LunarCraftingStation);
			st2.Register();
			Recipe st3 = Recipe.Create(ItemID.StardustLeggings, 1);
			st3.AddIngredient(ModContent.ItemType<Stardustbar>(), 7);
			st3.AddTile(TileID.LunarCraftingStation);
			st3.Register();
		}


	}

}