using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Projectiles
{
    public class BoulderProj : ModProjectile
    {

		public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.Boulder;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("boulderproj");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
			Projectile.DamageType = DamageClass.Magic;
			Projectile.friendly = true;
			Projectile.penetrate = int.MaxValue;
			AIType = ProjectileID.BoulderStaffOfEarth;
		}

    }
}
