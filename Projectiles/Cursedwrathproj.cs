using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;
using Microsoft.Xna.Framework;

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
			projectile.width = 34;
			projectile.height = 90;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.alpha = 255;
			projectile.tileCollide = false;
			projectile.melee = true;
			projectile.extraUpdates = 1;
		}
        public override void AI()
        {
			if (projectile.Center.Y >= projectile.ai[1])
			{
				projectile.tileCollide = true;
			}
			projectile.alpha -= 15;
			int num74 = 150;
			if (projectile.Center.Y >= projectile.ai[1])
			{
				num74 = 0;
			}
			if (projectile.alpha < num74)
			{
				projectile.alpha = num74;
			}
			projectile.localAI[0] += (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y)) * 0.01f * (float)projectile.direction;
			projectile.rotation = base.projectile.velocity.ToRotation() - (float)Math.PI / 2f;

			if (Main.rand.Next(16) == 0)
			{
				Vector2 value3 = Vector2.UnitX.RotatedByRandom(1.5707963705062866).RotatedBy(base.projectile.velocity.ToRotation());
				int num76 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 58, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, default(Color), 1.2f);
				Main.dust[num76].velocity = value3 * 0.66f;
				Main.dust[num76].position = base.projectile.Center + value3 * 12f;
			}
			if (Main.rand.Next(48) == 0)
			{
				int num77 = Gore.NewGore(base.projectile.Center, new Vector2(base.projectile.velocity.X * 0.2f, base.projectile.velocity.Y * 0.2f), 16);
				Gore gore = Main.gore[num77];
				gore.velocity *= 0.66f;
				gore = Main.gore[num77];
				gore.velocity += base.projectile.velocity * 0.3f;
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.CursedInferno, 900);
		}
        public override void Kill(int timeLeft)
        {
			Main.PlaySound(SoundID.Item10, base.projectile.position);
		}
    }
}