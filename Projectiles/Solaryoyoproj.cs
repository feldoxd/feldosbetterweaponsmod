using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Projectiles
{
	public class Solaryoyoproj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 450f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 18.5f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 99;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.light = 0.3f;
			projectile.scale = 1f;

		}

		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.SolarFlare, 16);
				dust.noGravity = true;
				dust.scale = 1.6f;
			}
		}
        public override void AI()
		{
			projectile.localAI[1] += 1f;
			if (projectile.localAI[1] >= 6f)
			{
				float num3 = 400f;
				Vector2 velocity = base.projectile.velocity;
				Vector2 vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
				vector.Normalize();
				vector *= (float)Main.rand.Next(10, 41) * 0.1f;
				if (Main.rand.Next(3) == 0)
				{
					vector *= 2f;
				}
				velocity *= 0.25f;
				velocity += vector;
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].CanBeChasedBy(this))
					{
						float num4 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
						float num5 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
						float num6 = System.Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num4) + System.Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num5);
						if (num6 < num3 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[j].position, Main.npc[j].width, Main.npc[j].height))
						{
							num3 = num6;
							velocity.X = num4;
							velocity.Y = num5;
							velocity -= base.projectile.Center;
							velocity.Normalize();
							velocity *= 8f;
						}
					}
				}
				velocity *= 1.3f;
				Projectile.NewProjectile(base.projectile.Center.X - velocity.X, base.projectile.Center.Y - velocity.Y, velocity.X, velocity.Y, ModContent.ProjectileType<Solaryoyofireproj>(), projectile.damage, projectile.knockBack, projectile.owner);
				projectile.localAI[1] = 0f;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 900);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}