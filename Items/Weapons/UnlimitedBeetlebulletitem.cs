﻿using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class UnlimitedBeetlebulletItem : ModItem
	{


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unlimited Beetle bullet");
			Tooltip.SetDefault("Warning: may be too accurate.\nUnlimited.");
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.knockBack = 4.5f;
			Item.value = Item.buyPrice(copper: 75);
			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<Projectiles.Beetlebullet>();
			Item.shootSpeed = 16f;
			Item.ammo = AmmoID.Bullet;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.BlizzardStaff)
			.AddIngredient(ModContent.ItemType<BeetlebulletItem>(), 9999)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}