using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Projectiles
{

	public class StarcannonMK2proj : ModProjectile
	{
		public override string Texture => "Terraria/Projectile_" + ProjectileID.FallingStar;

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.FallingStar);
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.penetrate = 3;
			projectile.localNPCHitCooldown = -1;
			projectile.extraUpdates = 0;
			aiType = 92;
		}
	}
}