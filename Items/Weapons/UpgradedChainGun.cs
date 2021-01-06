using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
//using Terraria.DataStructures;


namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class UpgradedChainGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Upgraded chain gun");
			Tooltip.SetDefault("It costs $400 000 dollars to fire this for 12 seconds.");
			//Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(51, 6));
		}

		public override void SetDefaults()
		{
			item.damage = 38; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 52; // hitbox width of the item
			item.height = 32; // hitbox height of the item
			item.useTime = 8; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 2; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 10000; // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.LightRed; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item40; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this //ProjectileID.PurificationPowder
			item.shootSpeed = 24f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.FragmentVortex, 20);
			recipe.AddIngredient(ItemID.ChainGun);
			recipe.AddIngredient(ItemID.VortexBeater);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .58f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
		
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.VortexBeaterRocket, damage, knockBack, player.whoAmI);
			return true;
		}
	}
}