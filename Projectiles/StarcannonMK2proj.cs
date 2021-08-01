using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Projectiles
{

	public class StarcannonMK2proj : ModProjectile
	{
		public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.HallowStar;
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.HallowStar);
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = -1;

		}
		public override void AI()
		{
			Projectile.type = 92;
		}
	}
}