using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Projectiles
{
	public class Solaryoyoproj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// The following sets are only applicable to yoyo that use aiStyle 99.
			// YoyosLifeTimeMultiplier is how long in seconds the yoyo will stay out before automatically returning to the player. 
			// Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1;
			// YoyosMaximumRange is the maximum distance the yoyo sleep away from the player. 
			// Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 450f;
			// YoyosTopSpeed is top speed of the yoyo Projectile. 
			// Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 18.5f;
		}

		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 99;
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.netImportant = true;
			Projectile.light = 0.3f;
			Projectile.scale = 1f;

		}
		// notes for aiStyle 99: 
		// localAI[0] is used for timing up to YoyosLifeTimeMultiplier
		// localAI[1] can be used freely by specific types
		// ai[0] and ai[1] usually point towards the x and y world coordinate hover point
		// ai[0] is -1f once YoyosLifeTimeMultiplier is reached, when the player is stoned/frozen, when the yoyo is too far away, or the player is no longer clicking the shoot button.
		// ai[0] being negative makes the yoyo move back towards the player
		// Any AI method can be used for dust, spawning Projectiles, etc specific to your yoyo.

		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare, 16);
				dust.noGravity = true;
				dust.scale = 1.6f;
			}
		}
        public override void AI()
		{
			Projectile.localAI[1] += 1f;
			if (Projectile.localAI[1] >= 6f)
			{
				float num3 = 400f;
				Vector2 velocity = base.Projectile.velocity;
				Vector2 vector = new(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
				vector.Normalize();
				vector *= (float)Main.rand.Next(10, 41) * 0.1f;
				if (Main.rand.NextBool(3))
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
						float num6 = System.Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num4) + System.Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num5);
						if (num6 < num3 && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[j].position, Main.npc[j].width, Main.npc[j].height))
						{
							num3 = num6;
							velocity.X = num4;
							velocity.Y = num5;
							velocity -= base.Projectile.Center;
							velocity.Normalize();
							velocity *= 8f;
						}
					}
				}
				velocity *= 1.3f;
				IEntitySource source = null;
				Projectile.NewProjectile( source,base.Projectile.Center.X - velocity.X, base.Projectile.Center.Y - velocity.Y, velocity.X, velocity.Y, ModContent.ProjectileType<Solaryoyofireproj>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
				Projectile.localAI[1] = 0f;
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire, 900);
		}
	}
}