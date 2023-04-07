using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Feldosbetterweaponsmod.Items;

namespace Feldosbetterweaponsmod.NPCs
{
    public class CustomSelling : GlobalNPC
    {
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            switch (npc.type)
            {
                case NPCID.Merchant:
                    {
                        items[npc.lastInteraction].SetDefaults(ModContent.ItemType<Milk>());
                        npc.lastInteraction++;
                    }
                    break;
            }
        }
    }
}