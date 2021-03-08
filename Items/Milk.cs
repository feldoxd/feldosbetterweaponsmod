using Terraria.ID;
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
			item.width = 29;
			item.height = 40;
			item.maxStack = 9999;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.UseSound = SoundID.Item3;
			item.value = Item.buyPrice(silver: 20);
			item.useAnimation = 17;
			item.useTime = 17;
			item.rare = ItemRarityID.White;
			item.consumable = true;
			item.buffType = BuffID.WellFed;
			item.buffTime = 36000;
		}
	}
}