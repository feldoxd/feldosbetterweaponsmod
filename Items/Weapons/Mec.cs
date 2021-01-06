using Terraria.ID;
using Terraria.ModLoader;

namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class Mec : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("mec"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("XDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD.");
		}

		public override void SetDefaults() 
		{
			item.damage = 5000000;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 5;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Healproj");
			item.shootSpeed = 15f;
		}
	}
}