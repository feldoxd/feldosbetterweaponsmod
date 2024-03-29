﻿using Feldosbetterweaponsmod.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Items.Weapons
{
    public class HellstoneWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // This method quickly sets the whip's properties.
            // Mouse over to see its parameters.
            Item.DefaultToWhip(ModContent.ProjectileType<HellstoneWhipProjectile>(), 30, 2, 4);

            Item.crit = 4;
            Item.height = 34;
            Item.width = 38;
            Item.shootSpeed = 4;
            Item.rare = ItemRarityID.Orange;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 14)
                .AddTile(TileID.Anvils)
                .Register();
        }

        // Makes the whip receive melee prefixes
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}