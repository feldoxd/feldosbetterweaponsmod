using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Projectiles
{
	public class Vampproj : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Knive");
		}

		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.alpha = 0;
			projectile.timeLeft = 600;
			projectile.penetrate = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
		}
	}
}
