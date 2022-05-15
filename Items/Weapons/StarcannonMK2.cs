using Feldosbetterweaponsmod.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class StarcannonMK2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star cannon MK2");
		}

		public override void SetDefaults()
		{
			item.damage = 110; 
			item.ranged = true; 
			item.width = 52;
			item.height = 18;
			item.useTime = 10; 
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 0; 
			item.value = Item.sellPrice(gold: 12);
			item.rare = ItemRarityID.Yellow; 
			item.UseSound = SoundID.Item11;
			item.autoReuse = true; 
			item.shoot = ModContent.ProjectileType<StarcannonMK2proj>();
			item.shootSpeed = 22f;
			item.useAmmo = AmmoID.FallenStar;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StarCannon);
			recipe.AddIngredient(ItemID.ShroomiteBar, 5);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddTile(TileID.MythrilAnvil );
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{	
			float rotation = MathHelper.ToRadians(-3);
			position += Vector2.Normalize(new Vector2(speedX, speedY));
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, 1 / (5 - 1))) * .90f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			
			return true;
		}
	}
}