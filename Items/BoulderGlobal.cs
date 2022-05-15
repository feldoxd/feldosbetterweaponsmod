using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Feldosbetterweaponsmod.Items
{
	public class BoulderGlobal : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.Boulder)
			{
				item.ammo = ItemID.Boulder;
			}
		}
	}
}
