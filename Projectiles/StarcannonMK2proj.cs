using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Projectiles
{

	public class StarcannonMK2proj : ModProjectile
	{
		public override string Texture => "Terraria/Projectile_" + ProjectileID.HallowStar;
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.HallowStar);
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;

		}
		public override void AI()
		{
			projectile.type = 92;
		}
	}
}