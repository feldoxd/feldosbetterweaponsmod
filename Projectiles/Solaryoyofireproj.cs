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
			Projectile.CloneDefaults(ProjectileID.TerrarianBeam);
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.netUpdate = true;
			Projectile.timeLeft = 8500;

		}
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
			return true;
		}
		public override void AI()
		{
			Main.player[Projectile.owner].Counterweight(Projectile.Center, Projectile.damage, Projectile.knockBack);
			Projectile.ai[1] = 1000f;

		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 900);
			base.OnHitNPC(target, damage, knockback, crit);
		}
		public override void Kill(int timeLeft)
		{
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 1.4f;
			dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
			Main.dust[dustIndex].noGravity = true;
			Main.dust[dustIndex].velocity *= 5f;
			dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 3f;
			base.Kill(timeLeft);
		}
	}
}