﻿
using FractalaMod.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FractalaMod.Drops
{
	public class BossBags : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			// This method shows adding items to Fishrons boss bag. 
			// Typically you'll also want to also add an item to the non-expert boss drops, that code can be found in ExampleGlobalNPC.NPCLoot. Use this and that to add drops to bosses.
			if (context == "bossBag" && arg == ItemID.SkeletronBossBag)
			{
				player.QuickSpawnItem(ItemType<HandCannon>(), Main.rand.Next(1, 1));
			}
		}
	}
}