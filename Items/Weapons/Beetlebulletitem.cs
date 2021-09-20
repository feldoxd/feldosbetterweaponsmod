using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class Beetlebulletitem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beetle bullet");
			Tooltip.SetDefault("Warning: may be too accurate.");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 9999;
			item.consumable = true;
			item.knockBack = 1.5f;
			item.value = Item.buyPrice(copper: 75);
			item.rare = ItemRarityID.Yellow;
			item.shoot = ModContent.ProjectileType<Projectiles.Beetlebullet>();
			item.shootSpeed = 16f;
			item.ammo = AmmoID.Bullet;
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
}