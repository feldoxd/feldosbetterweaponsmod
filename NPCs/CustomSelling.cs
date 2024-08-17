using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Items;

namespace Feldosbetterweaponsmod.NPCs
{
    public class CustomSelling : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            switch (shop.NpcType)
            {
                case NPCID.Merchant:
                    {
                        shop.Add(ModContent.ItemType<Milk>());
                        break;
                    }
            }
        }
    }
}