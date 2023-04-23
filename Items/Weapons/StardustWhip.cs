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
            // This method quickly sets the whip's properties.
            // Mouse over to see its parameters.
            Item.DefaultToWhip(ModContent.ProjectileType<StardustWhipProjectile>(), 200, 1, 15);

            Item.height = 34;
            Item.width = 38;
            Item.autoReuse = true;
            Item.shootSpeed = 5;
            Item.rare = ItemRarityID.Cyan;

            Item.channel = true;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
              .AddIngredient(ItemID.FragmentStardust, 18)
              .AddTile(TileID.LunarCraftingStation)
              .Register();
        }

        // Makes the whip receive melee prefixes
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}