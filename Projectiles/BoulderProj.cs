using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Projectiles
{
    public class BoulderProj : ModProjectile
    {

		public override string Texture => "Terraria/Projectile_" + ProjectileID.Boulder;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("boulderproj");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
			projectile.magic = true;
			projectile.ranged = false;
			projectile.friendly = true;
			projectile.penetrate = int.MaxValue;
			projectile.ranged = true;
			aiType = ProjectileID.BoulderStaffOfEarth;
		}

    }
}
