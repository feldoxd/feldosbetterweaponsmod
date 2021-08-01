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
            ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;
        }
        public override void SetDefaults()
		{
			Projectile.width = 56;
			Projectile.height = 56;
			Projectile.penetrate = -1;
			Projectile.aiStyle = 71;
			//Projectile.alpha = 255;
			Projectile.timeLeft = 360;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 2;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
		}

		public override void AI()
        {
			Vector2 lastVelocity = base.Projectile.velocity;
			if (base.Projectile.velocity.X != lastVelocity.X)
			{
				base.Projectile.velocity.X = lastVelocity.X * -1f;
			}
			if (base.Projectile.velocity.Y != lastVelocity.Y)
			{
				base.Projectile.velocity.Y = lastVelocity.Y * -1f;
			}
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<NebulaDust>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
                Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				Terraria.Audio.SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            return false;
        }
        public override void Kill(int timeLeft)
		{
			//Main.PlaySound(SoundID.Item25, Projectile.position);
		}
	}
}