using FractalaMod.Dusts;
using FractalaMod.Items;
using FractalaMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FractalaMod
{
    public class FractalaNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
		
        public bool Trueshadowflame;
        public override void ResetEffects(NPC npc)
        {
	        Trueshadowflame = false;
        }

		

		public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (Trueshadowflame) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 32;
				if (damage < 3) {
					damage = 3;
				}
			}
		}

		
			
		public override void DrawEffects(NPC npc, ref Color drawColor) {
			if (Trueshadowflame) {
				if (Main.rand.Next(4) < 3) {
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<ShadowFlameDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4)) {
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
		}

		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) {
			if (player.GetModPlayer<FractalaModPlayer>().zoneBiome) {
				spawnRate = (int)(spawnRate * 5f);
				maxSpawns = (int)(maxSpawns * 5f);
			}
		}

		
			
			}
		}




