using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class StarcannonMK2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star cannon MK2");
		}

		public override void SetDefaults()
		{
			item.damage = 89; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 52; // hitbox width of the item
			item.height = 18; // hitbox height of the item
			item.useTime = 7; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 10000; // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ProjectileID.HallowStar; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 22f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.FallenStar; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StarCannon);
			recipe.AddIngredient(ItemID.ShroomiteBar, 5);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddTile(TileID.MythrilAnvil );
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY));
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, 1 / (5 - 1))) * .90f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			
			return true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
	}
}