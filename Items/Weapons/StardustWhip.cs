using Feldosbetterweaponsmod.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Items.Weapons
{
    public class StardustWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<StardustWhipProjectile>(), 200, 1, 15);

            Item.crit = 6;
            Item.height = 34;
            Item.width = 38;
            Item.shootSpeed = 5;
            Item.rare = ItemRarityID.Cyan;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
              .AddIngredient(ItemID.FragmentStardust, 18)
              .AddTile(TileID.LunarCraftingStation)
              .Register();
        }

        public override bool MeleePrefix()
        {
            return true;
        }
    }
}