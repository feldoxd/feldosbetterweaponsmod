using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Projectiles
{
	public class CrystalBulletReplacement : ModProjectile
	{
		public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.CrystalBullet;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("CrystalBulletReplacement");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.DamageType = DamageClass.Magic;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.Bullet;
			return true;
		}

		/*public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < 5; i++)
			{
				EntitySource_TileBreak source = new((int)Projectile.position.X, (int)Projectile.position.Y);
				int a = Projectile.NewProjectile(source, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.CrystalShard, (int)(Projectile.damage * .5f), 0, Projectile.owner);
				Main.Projectile[a].aiStyle = 1;
				Main.Projectile[a].tileCollide = true;
				Main.Projectile[a].DamageType = DamageClass.Magic;
			}
			return true;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			for (int i = 0; i < 5; i++)
			{
				int a = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.CrystalShard, (int)(Projectile.damage * .5f), 0, Projectile.owner);
				Projectile[a].aiStyle = 1;
				Projectile[a].tileCollide = true;
				Projectile[a].DamageType = DamageClass.Magic;
			}
			return;
		}*/
    }
}