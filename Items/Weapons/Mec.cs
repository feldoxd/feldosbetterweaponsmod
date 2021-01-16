using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class Mec : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("mec");
			Tooltip.SetDefault("Warning. may crash your game xd.");
		}

		public override void SetDefaults() 
		{
			item.damage = 500000000;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 1;
			item.useAnimation = 1;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Quest;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileID.Meowmere;
			item.shootSpeed = 25f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = Main.rand.Next(new int[] { type, ProjectileID.ExplosiveBunny, ProjectileID.TerraBeam, ProjectileID.TerrarianBeam, ProjectileID.ChlorophyteBullet, ProjectileID.MolotovFire });
			int numberProjectiles = 8 + Main.rand.Next(100); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}
	}
}