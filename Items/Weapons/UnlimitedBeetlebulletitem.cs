using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class UnlimitedBeetlebulletitem : ModItem
	{


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unlimited Beetle bullet");
			Tooltip.SetDefault("Warning: may be too accurate.\nUnlimited.");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 1;
			item.consumable = false;
			item.knockBack = 4.5f;
			item.value = Item.buyPrice(copper: 75);
			item.rare = ItemRarityID.Yellow;
			item.shoot = ModContent.ProjectileType<Projectiles.Beetlebullet>();
			item.shootSpeed = 16f;
			item.ammo = AmmoID.Bullet;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Beetlebulletitem>(), 3996);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}