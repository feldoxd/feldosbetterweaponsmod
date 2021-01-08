using Feldosbetterweaponsmod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class Cowsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cow sword");
			Tooltip.SetDefault("boo.");
		}

		public override void SetDefaults() 
		{
			item.damage = 55;
			item.melee = true;
			item.width = 32;
			item.height = 64;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Coolprojectile>();
			item.shootSpeed = 25f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 35, position + muzzleOffset, 0, 35))
			{
				position += muzzleOffset;
			}
			return true;
		}
	}
}