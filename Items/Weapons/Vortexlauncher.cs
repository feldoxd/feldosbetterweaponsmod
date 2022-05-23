using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class VortexLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vortex launcher");
			Tooltip.SetDefault("Shoots 2 rockets for price of 1!");
		}

		public override void SetDefaults()
		{
			Item.damage = 100; // Sets the Item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.DamageType = DamageClass.Ranged;
			Item.width = 47; // hitbox width of the Item
			Item.height = 20; // hitbox height of the Item
			Item.useTime = 7; // The Item's use time in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // how you use the Item (swinging, holding out, etc)
			Item.noMelee = true; //so the Item's animation doesn't do damage
			Item.knockBack = 4; // Sets the Item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.value = Item.buyPrice(gold: 5);
			Item.rare = ItemRarityID.Cyan; // the color that the Item's name will be in-game
			Item.UseSound = SoundID.Item31;
			Item.autoReuse = true; // if you can hold click to automatically use it again
			Item.shoot = ProjectileID.RocketI;
			Item.shootSpeed = 16f; // the speed of the projectile (measured in pixels per frame)
			Item.useAmmo = AmmoID.Rocket; // The "ammo Id" of the ammo Item that this weapon uses. Note that this is not an Item Id, but just a magic value.


			Item.useAnimation = 36;
			Item.useTime = 12; // one third of useAnimation
			Item.reuseDelay = 14;
			Item.consumeAmmoOnLastShotOnly = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.RocketLauncher)
			.AddIngredient(ItemID.FragmentVortex, 5)
			.AddIngredient(ItemID.ClockworkAssaultRifle)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
        Vector2 muzzleOffset = Vector2.Normalize(position) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
	}
}