using Feldosbetterweaponsmod.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class StarcannonMK2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 110;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 52;
			Item.height = 18;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0f;
			Item.value = Item.sellPrice(gold: 12);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<StarcannonMK2proj>();
			Item.shootSpeed = 22f;
			Item.useAmmo = AmmoID.FallenStar;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.StarCannon)
			.AddIngredient(ItemID.ShroomiteBar, 5)
			.AddIngredient(ItemID.FallenStar, 5)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
		  float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(position);
				Vector2 perturbedSpeed = position.RotatedBy(MathHelper.Lerp(-rotation, rotation, 1 / (5 - 1))) * .90f;
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback);
			
			return true;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 40;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}

	}
}