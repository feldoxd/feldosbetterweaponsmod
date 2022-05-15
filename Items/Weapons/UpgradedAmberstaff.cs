using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class UpgradedAmberstaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hellstone staff");
			Tooltip.SetDefault("");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}
		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.width = 40;
			Item.height = 38;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(gold: 10);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.DiamondBolt;
			Item.shootSpeed = 19f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.AmberStaff)
			.AddIngredient(ItemID.Diamond, 3)
			.AddIngredient(ItemID.HellstoneBar, 3)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}