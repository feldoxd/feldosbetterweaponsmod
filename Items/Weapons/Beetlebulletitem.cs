using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class Beetlebulletitem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beetle bullet");
			Tooltip.SetDefault("Warning: may be too accurate.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 9999;
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 9999;
			Item.consumable = true;             //You need to set the Item consumable so that the ammo would automatically consumed
			Item.knockBack = 4.5f;
			Item.value = Item.buyPrice(copper: 75);
			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<Projectiles.Beetlebullet>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 16f;                  //The speed of the projectile
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.BeetleHusk)
			.AddIngredient(ItemID.ChlorophyteBullet, 60)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}