using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Projectiles;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class Nebulatyphoon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula typhoon");
			Tooltip.SetDefault("More aggressive, better version of razorblade typhoon");
		}
		public override void SetDefaults()
		{
			item.mana = 16;
			item.damage = 99;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 12f;
			item.shoot = ModContent.ProjectileType<NebulatyphoonProj>();
			item.width = 26;
			item.height = 28;
			item.UseSound = SoundID.Item84;
			item.useAnimation = 40;
			item.useTime = 26;
			item.autoReuse = true;
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.knockBack = 5f;
			item.scale = 0.9f;
			item.value = Item.sellPrice(gold: 8);
			item.magic = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RazorbladeTyphoon);
			recipe.AddIngredient(ItemID.SoulofLight, 20);
			recipe.AddIngredient(ItemID.FragmentNebula, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
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