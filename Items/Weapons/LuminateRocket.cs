﻿/*using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class LuminateRocket : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luminate Rocket");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.ranged = true;
			item.width = 21;
			item.height = 11;
			item.maxStack = 9999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = ItemRarityID.Yellow;
			item.shoot = ModContent.ProjectileType<Projectiles.LuminateRocketproj>();   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 16f;                  //The speed of the projectile
			item.ammo = AmmoID.Rocket;              //The ammo class this ammo belongs to.
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeetleHusk);
			recipe.AddIngredient(ItemID.ChlorophyteBullet, 60);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 60);
			recipe.AddRecipe();
		}
	}
}*/