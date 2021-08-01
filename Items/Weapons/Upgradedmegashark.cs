using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Feldosbetterweaponsmod.Projectiles;
using Terraria.DataStructures;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class Upgradedmegashark : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Upgraded Mega shark");
		}

		public override void SetDefaults()
		{
			Item.damage = 28; // Sets the Item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.DamageType = DamageClass.Ranged;
			Item.width = 64; // hitbox width of the Item
			Item.height = 29; // hitbox height of the Item
			Item.useTime = 4; // The Item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 20; // The length of the Item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // how you use the Item (swinging, holding out, etc)
			Item.noMelee = true; //so the Item's animation doesn't do damage
			Item.knockBack = 4; // Sets the Item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.value = Item.buyPrice(gold: 80);
			Item.rare = ItemRarityID.Yellow; // the color that the Item's name will be in-game
			//Item.UseSound = SoundID.Item11; // The sound that this Item plays when used.
			Item.autoReuse = true; // if you can hold click to automatically use it again
			Item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 28f; // the speed of the projectile (measured in pixels per frame)
			Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo Item that this weapon uses. Note that this is not an Item Id, but just a magic value.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Megashark)
			.AddIngredient(ItemID.BeetleHusk, 15)
			.AddIngredient(ItemID.ChlorophyteBar, 5)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .58f;
		}

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item11, player.whoAmI);
			Vector2 muzzleOffset = Vector2.Normalize(position) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			if (type == ProjectileID.ChlorophyteBullet)
			{
				type = ModContent.ProjectileType<Beetlebullet>();
			}
			return true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, 0);
		}
	}
}