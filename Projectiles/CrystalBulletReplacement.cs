using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Projectiles
{
	public class CrystalBulletReplacement : ModProjectile
	{
		public override string Texture => "Terraria/Projectile_" + ProjectileID.CrystalBullet;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("CrystalBulletReplacement");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.magic = true;
			projectile.ranged = false;
			aiType = ProjectileID.Bullet;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.Bullet;
			return true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < 5; i++)
			{
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.CrystalShard, (int)(projectile.damage * .5f), 0, projectile.owner);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].tileCollide = true;
				Main.projectile[a].ranged = false;
				Main.projectile[a].magic = true;
			}
			return true;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			for (int i = 0; i < 5; i++)
			{
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.CrystalShard, (int)(projectile.damage * .5f), 0, projectile.owner);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].tileCollide = true;
				Main.projectile[a].ranged = false;
				Main.projectile[a].magic = true;
			}
			return;
		}
    }
}