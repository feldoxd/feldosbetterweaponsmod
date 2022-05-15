using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Projectiles;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Items.Weapons
{
    public class BoulderCannon : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boulder cannon");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.StaffofEarth);
			item.magic = false;
			item.ranged = true;
			item.mana = 0;
			item.damage = 13;
			item.crit = 8;
			item.ranged = true;
			item.width = 42;
			item.height = 30;
			item.useTime = 40;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 8;
			item.value = Item.buyPrice(silver: 90);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<BoulderProj>();
			item.shootSpeed = 10f;
			item.useAmmo = ItemID.Boulder;
		}

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.Boulder);
			recipe.AddIngredient(ItemID.Wood, 35);
			recipe.AddIngredient(ItemID.StoneBlock, 45);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			item.shootSpeed = Main.rand.NextFloat(7f, 14f);
			return true;
        }

    }
}
