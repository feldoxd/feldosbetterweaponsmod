using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class VortexLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 47;
			Item.height = 20;
			Item.useTime = 7;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.buyPrice(gold: 5);
			Item.rare = ItemRarityID.Cyan; 
			Item.autoReuse = true;
			Item.shoot = ProjectileID.RocketI;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Rocket;


			Item.useAnimation = 15;
			Item.useTime = 5;
			Item.reuseDelay = 14;
			Item.consumeAmmoOnLastShotOnly = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.RocketLauncher)
			.AddIngredient(ItemID.ClockworkAssaultRifle)
			.AddIngredient(ItemID.FragmentVortex, 5)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			SoundEngine.PlaySound(SoundID.Item11);
			return true;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 45f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}
        }
}