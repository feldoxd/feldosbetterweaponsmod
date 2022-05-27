using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Feldosbetterweaponsmod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Feldosbetterweaponsmod.Items.Weapons
{
    public class BoulderCannon : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boulder cannon");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.StaffofEarth);
			Item.DamageType = DamageClass.Ranged;
			Item.mana = 0;
			Item.damage = 30;
			Item.crit = 8;
			Item.width = 47;
			Item.height = 24;
			Item.useTime = 50;
			Item.useAnimation = 50;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.buyPrice(silver: 90);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BoulderProj>();
			Item.shootSpeed = 5f;
			Item.useAmmo = ItemID.Boulder;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
			.AddIngredient(ItemID.IllegalGunParts)
			.AddIngredient(ItemID.Boulder)
			.AddIngredient(ItemID.Wood, 35)
			.AddIngredient(ItemID.StoneBlock, 45)
			.AddTile(TileID.TinkerersWorkbench)
			.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10f, 0f);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Item.shootSpeed = Main.rand.NextFloat(7f, 14f);
			return true;
        }

    }
}
