using FractalaMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace FractalaMod.Buffs
{
   
    public class BreakingDeath : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("True ShadowFlame");
            Description.SetDefault("As the Shadow Flames consume you your soul Darkens. ");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.GetModPlayer<FractalaModPlayer>().TrueShadowflame = true;
        }

        public override void Update(NPC npc, ref int buffIndex) {
            npc.GetGlobalNPC<FractalaNPC>().Trueshadowflame = true;
        }
    }
}