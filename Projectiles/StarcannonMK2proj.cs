using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Projectiles
{

	public class StarcannonMK2proj : ModProjectile
	{
		public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.FallingStar;
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.FallingStar);
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 3;

		}
		public override void AI()
		{
			Projectile.type = 92;
		}
	}
}