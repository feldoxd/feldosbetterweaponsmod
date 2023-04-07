using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class CrystalStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal staff");
			// Tooltip.SetDefault("More powerfull version of Blizzard staff combined with Crystal storm");
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 42;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 26;
			Item.width = 32;
			Item.height = 47;
			Item.useTime = 4;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5f;
			Item.value = Item.buyPrice(gold: 140);
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.CrystalBullet;
			Item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.BlizzardStaff)
			.AddIngredient(ItemID.CrystalStorm)
			.AddIngredient(ItemID.SoulofSight, 15)
			.AddIngredient(ItemID.FragmentNebula, 5)
			.AddTile(TileID.Anvils)
			.Register();

		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float speedX = velocity.X, speedY = velocity.Y;
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
				Projectile.NewProjectile(source, new Vector2(position.X, position.Y), new Vector2(speedX, speedY), type, (int)(damage * 1.25), knockback, player.whoAmI, 0f, ceilingLimit);
			}
			return false;
		}
	}
}