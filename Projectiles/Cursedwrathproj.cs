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
			projectile.width = 90;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.rotation = 0;
			projectile.timeLeft = 200;
			projectile.aiStyle = 5;
			projectile.MaxUpdates = 1;
			
		}
        public override void AI()
        {
			projectile.type = 503;
        }
    }
}