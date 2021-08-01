﻿using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Items
{
	public class Milk : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Milk");
		}

		public override void SetDefaults()
		{
			Item.width = 29;
			Item.height = 40;
			Item.maxStack = 9999;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.UseSound = SoundID.Item3;
			Item.value = Item.buyPrice(silver: 20);
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.rare = ItemRarityID.White;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed;
			Item.buffTime = 36000;
		}
	}
}