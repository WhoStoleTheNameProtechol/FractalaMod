using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria.ModLoader.IO;
using FractalaMod.Buffs;
using FractalaMod.Dusts;
using FractalaMod.Items;
using FractalaMod;
using FractalaMod.NPCs;
using FractalaMod;
using FractalaMod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;


namespace FractalaMod
{
    public class FractalaModPlayer : ModPlayer
    {
        public const int maxtesthearts = 10;
        public int testhearts;
        public bool zoneBiome = false;
        private bool pet;
        public bool Pet { get => pet; set => pet = value; }
        public bool CrewmatePet;
        public bool TrueShadowflame;
        public int playerdie;
        
	    
	        
        
        
         public override void UpdateBiomes()
        {
            zoneBiome = (FractalaModWorld.biomeTiles > 50); // Chance 50 to the minimum number of tiles that need to be counted before it is classed as a biome
        }

        	public override bool CustomBiomesMatch(Player other) {
			FractalaModPlayer modOther = other.GetModPlayer<FractalaModPlayer>();
			return zoneBiome == modOther.zoneBiome;
			
		}

		public override void CopyCustomBiomesTo(Player other) {
			FractalaModPlayer modOther = other.GetModPlayer<FractalaModPlayer>();
			modOther.zoneBiome = zoneBiome;
		}

		public override void SendCustomBiomes(BinaryWriter writer) {
			BitsByte flags = new BitsByte();
			flags[0] = zoneBiome;
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader) {
			BitsByte flags = reader.ReadByte();
			zoneBiome = flags[0];
		}

		public override void UpdateBiomeVisuals() {
			
		}

		public override Texture2D GetMapBackgroundImage() {
			if (zoneBiome) {
				return mod.GetTexture("Backrounddeadsilence");
			}
			return null;
		}
        
        public override void ResetEffects()
        {
            CrewmatePet = false;
            player.statLifeMax2 += testhearts * 100;
            TrueShadowflame = false;
            playerdie = 0;
        }
       

       //white space

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) // this code makes the hearts SYNC with mulitplayer
        {
            ModPacket packet = mod.GetPacket();
            packet.Write(testhearts);
            packet.Send(toWho, fromWho);
        }
        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"testhearts", testhearts}
            };
        }
        public override void Load(TagCompound tag)
        {
            testhearts = tag.GetInt("testhearts");
        }
        
        public override void UpdateDead() {
	        TrueShadowflame = false;
        }
        public override void UpdateBadLifeRegen() {
	        if (TrueShadowflame) {
		        // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
		        if (player.lifeRegen > 0) {
			        player.lifeRegen = 0;
		        }
		        player.lifeRegenTime = 0;
		        // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 10 life lost per second.
		        player.lifeRegen -= 20;
	        }

	        if (playerdie > 0)
	        {
		        if (player.lifeRegen > 0)
		        {
			        player.lifeRegen = 0;
		        }

		        player.lifeRegenTime = 0;
		        player.lifeRegen -= 120 * playerdie;
	        }}
	        
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
	        
		        
	        
	        if (playerdie > 0 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) {
		        damageSource = PlayerDeathReason.ByCustomReason(" Soul was corrupted ");
	        }
	        return true;
        }
        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
	        if (TrueShadowflame) {
		        if (Main.rand.NextBool(4) && drawInfo.shadow == 0f) {
			        int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, ModContent.DustType<ShadowFlameDust>(), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
			        Main.dust[dust].noGravity = true;
			        Main.dust[dust].velocity *= 1.8f;
			        Main.dust[dust].velocity.Y -= 0.5f;
			        Main.playerDrawDust.Add(dust);
		        }
		        r *= 0.1f;
		        g *= 0.2f;
		        b *= 0.7f;
		        fullBright = true;
	        }
	        
        }
        }
     } 
    
    



    







