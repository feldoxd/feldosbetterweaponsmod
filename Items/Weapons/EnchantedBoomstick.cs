using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class EnchantedBoomstick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted boomstick");
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.crit = 6;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 16;
			Item.useTime = 40;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 90);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = false;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Boomstick)
			.AddIngredient(ItemID.FallenStar, 15)
			.AddIngredient(ItemID.MeteoriteBar, 5)
			.AddTile(TileID.Anvils)
			.Register();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = position.RotatedByRandom(MathHelper.ToRadians(10));
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
			}
				Vector2 muzzleOffset = Vector2.Normalize(velocity) * 10f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			type = ProjectileID.HallowStar;
			return true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(- 5, 0);
		}
	}

}