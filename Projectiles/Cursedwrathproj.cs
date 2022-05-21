using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria;
using System;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Projectiles
{
	public class Cursedwrathproj : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed wrath Projectile");
		}
		public override void SetDefaults()
		{
			Projectile.width = 34;
			Projectile.height = 90;
			Projectile.friendly = true;
			Projectile.penetrate =-1;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.extraUpdates = 1;
		}
        public override void AI()
        {
			if (Projectile.Center.Y >= Projectile.ai[1])
			{
				Projectile.tileCollide = true;
			}
			Projectile.alpha -= 15;
			int num74 = 150;
			if (Projectile.Center.Y >= Projectile.ai[1])
			{
				num74 = 0;
			}
			if (Projectile.alpha < num74)
			{
				Projectile.alpha = num74;
			}
			Projectile.localAI[0] += (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y)) * 0.01f * (float)Projectile.direction;
			Projectile.rotation = base.Projectile.velocity.ToRotation() - (float)Math.PI / 2f;

			if (Main.rand.Next(16) == 0)
			{
				Vector2 value3 = Vector2.UnitX.RotatedByRandom(1.5707963705062866).RotatedBy(base.Projectile.velocity.ToRotation());
				int num76 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 58, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, default(Color), 1.2f);
				Main.dust[num76].velocity = value3 * 0.66f;
				Main.dust[num76].position = base.Projectile.Center + value3 * 12f;
			}
			if (Main.rand.Next(48) == 0)
			{
				EntitySource_TileBreak source = new ((int)Projectile.position.X, (int)Projectile.position.Y);
				int num77 = Gore.NewGore(source, new Vector2(base.Projectile.velocity.X * 0.2f), new Vector2(base.Projectile.velocity.Y * 0.2f), 16);
				Gore gore = Main.gore[num77];
				gore.velocity *= 0.66f;
				gore = Main.gore[num77];
				gore.velocity += base.Projectile.velocity * 0.3f;
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.CursedInferno, 900);
		}
        public override void Kill(int timeLeft)
        {
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item10, base.Projectile.position);
		}
    }
}