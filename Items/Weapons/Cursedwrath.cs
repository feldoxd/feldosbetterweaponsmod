using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Projectiles;
using Feldosbetterweaponsmod.Items.Placeable;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class Cursedwrath : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed wrath");
		}

		public override void SetDefaults()
		{
			item.damage = 125;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 20;
			item.knockBack = 9;
			item.value = Item.buyPrice(gold: 100);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
			item.crit = 32;
			item.shoot = ModContent.ProjectileType<Cursedwrathproj>();
			item.shootSpeed = 16f;
			item.useStyle = ItemUseStyleID.SwingThrow;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 20);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.CursedFlame, 30);
			recipe.AddIngredient(ItemID.StarWrath);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Solarbar>(), 10);
			recipe.AddIngredient(ItemID.CursedFlame, 30);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.StarWrath);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.SolarFlare);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 900);
			target.AddBuff(BuffID.ShadowFlame, 900, true);
			target.AddBuff(BuffID.OnFire, 900, true);
			target.AddBuff(BuffID.Suffocation, 900, true);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 position2 = position;
			float speedX2 = speedX;
			float speedY2 = speedY;
			int type2;
			int damage2 = damage;
			float knockBack2 = knockBack;
			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			for (int i = 0; i < 3; i++)
			{
				position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
				position.Y -= (100 * i);
				Vector2 heading = target - position;
				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}
				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}
				heading.Normalize();
				heading *= new Vector2(speedX, speedY).Length();
				speedX = heading.X;
				speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 2, knockBack, player.whoAmI, 0f, ceilingLimit);
			}
			type2 = ProjectileID.TerraBeam;
			Projectile.NewProjectile(position2.X, position2.Y, speedX2, speedY2, type2, damage2, knockBack2, player.whoAmI);
			return true;
		}
	}
}