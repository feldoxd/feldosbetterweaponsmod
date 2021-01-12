using Feldosbetterweaponsmod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class Glue : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Glue");
			ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Grenade);
			item.damage = 70;
			item.melee = false;
			item.noMelee = true;
			item.ranged = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Glueproj>();
			item.shootSpeed = 10f;
		}
	}
}