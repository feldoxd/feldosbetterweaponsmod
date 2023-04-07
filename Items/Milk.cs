using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Feldosbetterweaponsmod.Items
{
	public class Milk : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Milk");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 255;
            //ItemID.Sets.IsFood[Type] = true;

            ItemID.Sets.FoodParticleColors[Item.type] = new Color[1] {
                new Color(255, 255, 255)
            };
        }

		public override void SetDefaults()
		{
			Item.width = 29;
			Item.height = 40;
			Item.maxStack = 9999;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.UseSound = SoundID.Item3;
			Item.value = Item.buyPrice(silver: 20, copper: 1);
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.rare = ItemRarityID.White;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed;
			Item.buffTime = 36000;
		}
	}
}