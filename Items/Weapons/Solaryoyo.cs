using Feldosbetterweaponsmod.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria.Utilities;
using Terraria.DataStructures;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class Solaryoyo : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar yoyo");

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 27;
			Item.height = 23;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 16f;
			Item.knockBack = 2.5f;
			Item.damage = 200;
			Item.crit = 31;
			Item.rare = ItemRarityID.Purple;

			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = false;

			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(gold: 26);
			Item.shoot = ModContent.ProjectileType<Solaryoyoproj>();
		}

		// Make sure that your Item can even receive these prefixes (check the vanilla wiki on prefixes)
		// These are the ones that reduce damage of a melee weapon
		private static readonly int[] unwantedPrefixes = new int[] { PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy };

		public override bool AllowPrefix(int pre)
		{

			if (Array.IndexOf(unwantedPrefixes, pre) > -1)
			{
				return false;
			}

			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<Solarbar>(), 10)
			.AddIngredient(ItemID.Terrarian)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}
    }
}