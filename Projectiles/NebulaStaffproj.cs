using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Feldosbetterweaponsmod.Projectiles
{
    public class NebulaStaffproj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
        }

        public override void AI()
        {
            projectile.velocity.Y += projectile.ai[0];
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.WitherLightning, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            int num582 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 21, base.projectile.oldVelocity.X, base.projectile.oldVelocity.Y, 50, default(Color), 1.2f);
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
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.PinkFlame, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
            Main.PlaySound(SoundID.Item25, projectile.position);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

                float num132 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
                float num133 = projectile.localAI[0];
                if (num133 == 0f)
                {
                    projectile.localAI[0] = num132;
                    num133 = num132;
                }
                float num134 = projectile.position.X;
                float num135 = projectile.position.Y;
                float num136 = 20000000f;
                bool flag3 = false;
                int num137 = 0;
                if (projectile.ai[1] == 0f)
                {
                    for (int num138 = 0; num138 < 200; num138++)
                    {
                        if (Main.npc[num138].CanBeChasedBy(this, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num138 + 1)))
                        {
                            float num139 = Main.npc[num138].position.X + (float)(Main.npc[num138].width / 2);
                            float num140 = Main.npc[num138].position.Y + (float)(Main.npc[num138].height / 2);
                            float num141 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num139) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num140);
                            if (num141 < num136 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num138].position, Main.npc[num138].width, Main.npc[num138].height))
                            {
                                num136 = num141;
                                num134 = num139;
                                num135 = num140;
                                flag3 = true;
                                num137 = num138;
                            }
                        }
                    }
                    if (flag3)
                    {
                        projectile.ai[1] = (float)(num137 + 1);
                    }
                    flag3 = false;
                }
                if (projectile.ai[1] > 0f)
                {
                    int num142 = (int)(projectile.ai[1] - 1f);
                    if (Main.npc[num142].active && Main.npc[num142].CanBeChasedBy(this, true) && !Main.npc[num142].dontTakeDamage)
                    {
                        float num143 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
                        float num144 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
                        if (Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num143) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num144) < 1000f)
                        {
                            flag3 = true;
                            num134 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
                            num135 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
                        }
                    }
                    else
                    {
                        projectile.ai[1] = 0f;
                    }
                }
                if (!projectile.friendly)
                {
                    flag3 = false;
                }
                if (flag3)
                {
                    float num145 = num133;
                    Vector2 vector10 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    float num146 = num134 - vector10.X;
                    float num147 = num135 - vector10.Y;
                    float num148 = (float)Math.Sqrt((double)(num146 * num146 + num147 * num147));
                    num148 = num145 / num148;
                    num146 *= num148;
                    num147 *= num148;
                    int num149 = 8;
                    projectile.velocity.X = (projectile.velocity.X * (float)(num149 - 1) + num146) / (float)num149;
                    projectile.velocity.Y = (projectile.velocity.Y * (float)(num149 - 1) + num147) / (float)num149;
                    Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
                }
            
        }
    }
}