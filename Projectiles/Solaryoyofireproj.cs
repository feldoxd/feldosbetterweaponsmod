using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;


namespace Feldosbetterweaponsmod.Projectiles
{
	public class Solaryoyofireproj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.TerrarianBeam);
			projectile.width = 20;
			projectile.height = 20;
			projectile.netUpdate = true;
			projectile.timeLeft = 8500;

		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = Main.projectileTexture[projectile.type];
			spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
			return true;
		}
		public override void AI()
		{
			Main.player[projectile.owner].Counterweight(projectile.Center, projectile.damage, projectile.knockBack);
			projectile.ai[1] = 1000f;
			/*projectile.alpha += 8;
			if (projectile.alpha > 255)
			{
				projectile.alpha = 255;
			}*/
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 900);
			base.OnHitNPC(target, damage, knockback, crit);
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item14, projectile.position);
			int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 1.4f;
			dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
			Main.dust[dustIndex].noGravity = true;
			Main.dust[dustIndex].velocity *= 5f;
			dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 3f;
			base.Kill(timeLeft);
		}
	}
}