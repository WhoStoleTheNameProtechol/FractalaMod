using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace FractalaMod
{

    public class FractalaModWorld : ModWorld
    {
        public static int biomeTiles = 0;
       

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int GraniteIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Granite"));
            if(GraniteIndex != -1)
            {
                tasks.Insert(GraniteIndex + 1, new PassLegacy("The broken fractals", delegate (GenerationProgress progress)
                {
                    progress.Message = "The broken fractals";
                    for (int i = 0; i < 4; i++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY - 200), (double)WorldGen.genRand.Next(100, 200), WorldGen.genRand.Next(50, 150), mod.TileType("ColdDirtBlock"), true, 0f, 0f, false, true);
                    }
                }));
            }
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            biomeTiles = tileCounts[mod.TileType("ColdDirtBlock")];
        }

        public override void ResetNearbyTileEffects()
        {
            biomeTiles = 0;
        }
    }
}
