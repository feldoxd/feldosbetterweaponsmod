using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Items;

namespace Feldosbetterweaponsmod.NPCs
{
    public class CustomSelling : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Merchant:
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Milk>());
                        nextSlot++;
                    }
                    break;
            }
        }
    }
}