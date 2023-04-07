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
			// DisplayName.SetDefault("Star cannon MK2");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 110; // Sets the Item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.DamageType = DamageClass.Ranged;
			Item.width = 52; // hitbox width of the Item
			Item.height = 18; // hitbox height of the Item
			Item.useTime = 10; // The Item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 10; // The length of the Item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // how you use the Item (swinging, holding out, etc)
			Item.noMelee = true; //so the Item's animation doesn't do damage
			Item.knockBack = 0f; // Sets the Item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.value = Item.sellPrice(gold: 12);
			Item.rare = ItemRarityID.Yellow; // the color that the Item's name will be in-game
			Item.UseSound = SoundID.Item11; // The sound that this Item plays when used.
			Item.autoReuse = true; // if you can hold click to automatically use it again
			Item.shoot = ModContent.ProjectileType<StarcannonMK2proj>(); //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 22f; // the speed of the projectile (measured in pixels per frame)
			Item.useAmmo = AmmoID.FallenStar; // The "ammo Id" of the ammo Item that this weapon uses. Note that this is not an Item Id, but just a magic value.
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
				Vector2 perturbedSpeed = position.RotatedBy(MathHelper.Lerp(-rotation, rotation, 1 / (5 - 1))) * .90f; // Watch out for dividing by 0 if there is only 1 projectile.
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