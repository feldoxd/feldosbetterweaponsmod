using Terraria.ModLoader;
using Terraria.ID;

namespace Feldosbetterweaponsmod.Items.Placeable
{
	public class MUSICdoometernalcultistbase : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Box (Doom eternal - cultist base(does not work))");
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.MUSICdoometernalcultistbase>();
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.LightRed;
			item.value = 100000;
			item.accessory = true;
		}
	}
}