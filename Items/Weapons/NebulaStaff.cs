using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class NebulaStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula staff");
			Item.staff[Item.type] = true;
		}
		public override void SetDefaults()
		{
			Item.damage = 170;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 15;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 12;
			Item.useAnimation = 25;
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
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(position) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
	}
}