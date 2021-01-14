using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Feldosbetterweaponsmod.Projectiles;


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
			item.damage = 28; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 64; // hitbox width of the item
			item.height = 29; // hitbox height of the item
			item.useTime = 4; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 10000; // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			//item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 28f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Megashark);
			recipe.AddIngredient(ItemID.BeetleHusk, 15);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .58f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(SoundID.Item11, player.whoAmI);
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
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