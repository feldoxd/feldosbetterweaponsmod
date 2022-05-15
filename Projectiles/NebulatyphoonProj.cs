using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Dusts;


namespace Feldosbetterweaponsmod.Projectiles
{
	public class NebulatyphoonProj : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Homing[projectile.type] = true;
        }
        public override void SetDefaults()
		{
			projectile.width = 56;
			projectile.height = 56;
			projectile.penetrate = -1;
			projectile.aiStyle = 71;
			projectile.timeLeft = 360;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Typhoon;
		}

		public override void AI()
        {
			Vector2 lastVelocity = base.projectile.velocity;
			if (base.projectile.velocity.X != lastVelocity.X)
			{
				base.projectile.velocity.X = lastVelocity.X * -1f;
			}
			if (base.projectile.velocity.Y != lastVelocity.Y)
			{
				base.projectile.velocity.Y = lastVelocity.Y * -1f;
			}
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<NebulaDust>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item10, projectile.position);
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            return false;
        }

	}
}