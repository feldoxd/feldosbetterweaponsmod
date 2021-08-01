using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Projectiles;
using Feldosbetterweaponsmod.Items.Placeable;
using Terraria.DataStructures;

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
			Item.damage = 125; // The damage your Item deals
			Item.DamageType = DamageClass.Melee;
			Item.width = 40; // The Item texture's width
			Item.height = 40; // The Item texture's height
			Item.useTime = 10; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
			Item.useAnimation = 20;
			Item.knockBack = 6f;
			Item.value = Item.buyPrice(gold: 290);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item9;
			Item.autoReuse = true;
			Item.crit = 24;
			Item.shoot = ModContent.ProjectileType<Cursedwrathproj>();
			Item.shootSpeed = 16f;
			Item.useStyle = ItemUseStyleID.Swing;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.FragmentSolar, 20)
			.AddIngredient(ItemID.LunarBar, 10)
			.AddIngredient(ItemID.CursedFlame, 30)
			.AddIngredient(ItemID.StarWrath)
			.AddIngredient(ItemID.TerraBlade)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<Solarbar>(), 10)
			.AddIngredient(ItemID.CursedFlame, 30)
			.AddIngredient(ItemID.TerraBlade)
			.AddIngredient(ItemID.StarWrath)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
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
		}
        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{

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
				heading *= position.Length();
				//position = heading.X;
				//speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;

				Projectile.NewProjectile(source ,position, velocity, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
			}
			return false;
		}
	}
}