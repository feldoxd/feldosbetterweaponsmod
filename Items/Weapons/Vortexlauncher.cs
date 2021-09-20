using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

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
			item.damage = 100;
			item.ranged = true;
			item.width = 47;
			item.height = 20;
			item.useTime = 7;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.reuseDelay = 20;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.buyPrice(gold: 5);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item31;
			item.autoReuse = true;
			item.shoot = ProjectileID.RocketI;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Rocket;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RocketLauncher);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool ConsumeAmmo(Player player)
		{
			return !(player.itemAnimation < item.useAnimation - 2);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
	}
}