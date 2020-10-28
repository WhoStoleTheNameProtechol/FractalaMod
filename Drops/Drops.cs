using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FractalaMod.Drops
{
    public class ModGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            //The if (Main.rand.Next(x) == 0) determines how rare the drop is. To find the percent of a drop, divide 100 by your desired percent, minus the percent sign. Ex: A 2% chance would be 100% / 2%, or 50. This is what you put in place of x.

            if (Main.rand.Next(25) == 0) //25% chance
            {
                if (npc.type == NPCID.Shark)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MariniumShard"));
                }
                if (npc.type == NPCID.SeaSnail)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MariniumShard"));
                }
                if (npc.type == NPCID.Squid)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MariniumShard"));
                }
                if (npc.type == NPCID.Crab)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MariniumShard"));
                }
                if (npc.type == NPCID.PinkJellyfish)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MariniumShard"));

                                {

                                }
                            }
                        }
                    }
                }
            }
        
    

    


               
