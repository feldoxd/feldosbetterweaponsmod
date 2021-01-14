using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Projectiles
{
	public class Cursedwrathproj : ModProjectile
	{
		public override string Texture => "Terraria/Projectile_" + ProjectileID.StarWrath;

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

        public override void AI()
        {
			//pls help. pls tell the star wrath ai pls thank
            base.AI();
        }
    }
}