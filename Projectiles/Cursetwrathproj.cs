using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Projectiles
{
	public class Cursedwrathproj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed wrath projectile");
		}
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.StarWrath);
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 200;
		}
	}
}