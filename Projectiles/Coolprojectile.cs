using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Projectiles
{
	public class Coolprojectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 58;
			projectile.height = 62;
			projectile.alpha = 0;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 500;
		}

	}
}