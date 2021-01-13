using Terraria.ID;
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
			item.value = 1000;
			item.useAnimation = 17;
			item.useTime = 17;
			item.rare = ItemRarityID.White;
			item.consumable = true;
			item.buffType = BuffID.WellFed; //Specify an existing buff to be applied when used.
			item.buffTime = 36000; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock);
			recipe.SetResult(this, 999);
			recipe.AddRecipe();
		}*/
	}
}