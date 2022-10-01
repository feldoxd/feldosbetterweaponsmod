using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class EnchantedBoomstick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted boomstick");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.crit = 6;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 16;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 90);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
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

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(3f, 0f);
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * -40;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			float numberProjectiles = 2 + Main.rand.Next(2); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(velocity) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .3f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}

			type = ProjectileID.HallowStar;
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
			return true;

		}
	}

}