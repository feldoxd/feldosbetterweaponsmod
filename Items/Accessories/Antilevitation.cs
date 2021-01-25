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
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(32, 3));
		}

		public override void SetDefaults() {
			item.width = 20;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 30);
			item.rare = ItemRarityID.Cyan;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[164] = true;
		}

		public override int ChoosePrefix(UnifiedRandom rand) {
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.IronBar, 2);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
