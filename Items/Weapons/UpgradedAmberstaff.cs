using Feldosbetterweaponsmod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class UpgradedAmberstaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Upgraded amber staff");
			Tooltip.SetDefault("");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}
		public override void SetDefaults()
		{
			item.damage = 32;
			item.magic = true;
			item.mana = 6;
			item.width = 40;
			item.height = 38;
			item.useTime = 23;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileID.DiamondBolt;
			//item.shoot = ModContent.ProjectileType<Amberproj>();
			item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AmberStaff);
			recipe.AddIngredient(ItemID.Diamond, 3);
			recipe.AddIngredient(ItemID.HellstoneBar, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}