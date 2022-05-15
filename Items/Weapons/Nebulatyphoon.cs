using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class Nebulatyphoon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula typhoon");
			Tooltip.SetDefault("More aggressive, better version of razorblade typhoon");
		}
		public override void SetDefaults()
		{
			Item.mana = 16;
			Item.damage = 100;
			Item.useStyle = ItemUseStyleID.None;
			Item.shootSpeed = 12f;
			Item.shoot = ModContent.ProjectileType<NebulatyphoonProj>();
			Item.width = 26;
			Item.height = 28;
			Item.UseSound = SoundID.Item84;
			Item.useAnimation = 40;
			Item.useTime = 18;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Yellow;
			Item.noMelee = true;
			Item.knockBack = 5f;
			Item.scale = 0.9f;
			Item.value = Item.sellPrice(gold: 8);
			Item.DamageType = DamageClass.Magic;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.RazorbladeTyphoon)
			.AddIngredient(ItemID.SoulofLight, 20)
			.AddIngredient(ItemID.FragmentNebula, 15)
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