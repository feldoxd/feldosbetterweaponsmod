using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Utilities;

namespace Feldosbetterweaponsmod.Items.Accessories
{
	public class AntiLevitation : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Imunity to levitation.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(32, 3));
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Cyan;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[164] = true;
		}

		public override int ChoosePrefix(UnifiedRandom rand) {
			// When the Item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}

		public override void AddRecipes() {
			CreateRecipe()
			.AddIngredient(ItemID.FragmentVortex, 5)
			.AddIngredient(ItemID.IronBar, 8)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}
	}
}
