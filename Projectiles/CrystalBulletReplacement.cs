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
			// DisplayName.SetDefault("CrystalBulletReplacement");
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

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < 5; i++)
			{
				EntitySource_TileBreak source = new((int)Projectile.position.X, (int)Projectile.position.Y);
				int a = Projectile.NewProjectile(source, new Vector2(Main.rand.Next(-10, 11) * .25f), new Vector2(Main.rand.Next(-10, -5) * .25f), ProjectileID.CrystalShard, (int)(Projectile.damage * .5f), 0, Projectile.owner);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].tileCollide = true;
				Main.projectile[a].DamageType = DamageClass.Magic;
			}
			return true;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			for (int i = 0; i < 5; i++)
			{
				EntitySource_TileBreak source = new((int)Projectile.position.X, (int)Projectile.position.Y);
				int a = Projectile.NewProjectile(source,  16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.CrystalShard, (int)(Projectile.damage * .5f), 0, Projectile.owner);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].tileCollide = true;
				Main.projectile[a].DamageType = DamageClass.Magic;
			}
			return;
		}
    }
}