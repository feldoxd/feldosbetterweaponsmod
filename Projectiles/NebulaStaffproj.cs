using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Projectiles
{
    public class NebulaStaffproj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
        }

        public override void AI()
        {
            Projectile.velocity.Y += Projectile.ai[0];
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.WitherLightning, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }
            int num582 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 21, base.Projectile.oldVelocity.X, base.Projectile.oldVelocity.Y, 50, default(Color), 1.2f);
            Main.dust[num582].noGravity = true;
            Dust dust = Main.dust[num582];
            dust.scale *= 1.75f;
            dust = Main.dust[num582];
            dust.velocity *= 1f;
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.SilverFlame, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
            }
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item25, Projectile.position);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        }
    }
}