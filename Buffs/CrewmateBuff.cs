using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FractalaMod.Buffs
{
    public class CrewmateBuff : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Crewmate");
            Description.SetDefault("Red is ALWAYS the impostor.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }
        
        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<FractalaModPlayer>().CrewmatePet = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("CrewmatePetProjectile")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("CrewmateProjectile"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}