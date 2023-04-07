using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Projectiles;
using Terraria.GameContent.Creative;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class NebulaStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Nebula staff");
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 170;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 20;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(gold: 40);
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<NebulaStaffproj>();
			Item.shootSpeed = 21f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.NebulaBlaze)
			.AddIngredient(ItemID.SoulofNight, 20)
			.AddIngredient(ItemID.FragmentNebula, 5)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}
	}
}